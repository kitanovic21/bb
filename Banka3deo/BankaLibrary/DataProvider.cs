namespace BankaLibrary;
public static class DataProvider
{
    #region Transakcije
    public static async Task<Result<List<TransakcijeView>, ErrorMessage>> GetAllTransakcije() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await Task.Run(() =>
                        s.QueryOver<Transakcija>()
                            .Fetch(SelectMode.Fetch, t => t.Racun)
                            .Fetch(SelectMode.Fetch, t => t.NaKojiRacun)
                            .List()
                    );

            List<TransakcijeView> transakcije = entiteti
                .Select(t => new TransakcijeView(t))
                .ToList();

            return transakcije;
        }
        catch (Exception ex)
        {
            return $"Greška: {ex.Message} | Inner: {ex.InnerException?.Message}".ToError(400);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
    }
    public static async Task<Result<TransakcijeView, ErrorMessage>> GetTransakcijaByID(int id) // DAJ BAS OVAJ
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var transakcija = await s.GetAsync<Transakcija>(id);
            if (transakcija == null)
                return $"Transakcija sa ID-jem {id} nije pronađena.".ToError(404);

            return new TransakcijeView(transakcija);
        }
        catch (Exception)
        {
            return "Došlo je do greške prilikom dohvatanja transakcije.".ToError(400);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
    }
    public static async Task<Result<List<TransakcijeView>, ErrorMessage>> GetTransakcijeByRacun(string brojRacuna) // DAJ SA OVOG RACUNA
    {
        List<TransakcijeView> data = new();
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.".ToError(403);
            }

            var transakcije = await s.QueryOver<Transakcija>()
                                     .Where(t => t.Racun.BrojRacuna == brojRacuna)
                                     .ListAsync();

            data = transakcije.Select(t => new TransakcijeView(t)).ToList();
        }
        catch (Exception)
        {
            return "Došlo je do greške prilikom dohvatanja transakcija za zadati račun.".ToError(400);
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return data;
    }

    public static double KonvertujValutu(double iznos, string izValute, string uValutu)
    {
        if (izValute == uValutu)
            return iznos;

        // U realnom sistemu ovo se vuce sa APIja
        Dictionary<string, double> kurseviURsd = new Dictionary<string, double>()
            {
                { "RSD", 1.0 },
                { "EUR", 117.2 },
                { "USD", 108.0 },
                { "CHF", 122.5 }
            };

        if (!kurseviURsd.ContainsKey(izValute) || !kurseviURsd.ContainsKey(uValutu))
            throw new Exception($"Valuta {izValute} ili {uValutu} nije podržana za konverziju.");

        double iznosURsd = iznos * kurseviURsd[izValute];
        double krajnjiIznos = iznosURsd / kurseviURsd[uValutu];

        return Math.Round(krajnjiIznos, 2);
    }
    public static async Task<Result<bool, ErrorMessage>> AddTransakcija(TransakcijeView tv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Racun? posiljalac = tv.BrojRacunaPosiljalac == null ? null : await session.GetAsync<Racun>(tv.BrojRacunaPosiljalac);
            Racun? primalac = tv.BrojRacunaPrimalac == null ? null : await session.GetAsync<Racun>(tv.BrojRacunaPrimalac);

            if (posiljalac == null && tv.TipTransakcije != "Uplata")
                return "Izabrani posiljalac ne postoji.".ToError(404);
            if (primalac == null && tv.TipTransakcije != "Isplata")
                return "Račun primalaca ne postoji.".ToError(404);

            double iznosUValutiPosiljaoca = posiljalac != null ? KonvertujValutu(tv.Iznos, tv.Valuta, posiljalac.Valuta) : 0;
            double iznosUValutiPrimaoca = primalac != null ? KonvertujValutu(tv.Iznos, tv.Valuta, primalac.Valuta) : 0;

            // 1 Kao na bankomatu unosi se samo BrojRacunaPrimalaca i tu se dodaje
            if (tv.TipTransakcije == "Uplata")
            {
                if (tv.Status == "Odobrena")
                {
                    primalac.TrenutnoStanje += iznosUValutiPrimaoca;
                    await session.UpdateAsync(primalac);
                }
            }
            // 2 Kao na bankomatu unosti se samo BrojRacunaPosiljaoca i odatle se skida
            else
            {
                if (posiljalac.TrenutnoStanje - iznosUValutiPosiljaoca < -posiljalac.DozvoljeniMinus)
                {
                    tv.Status = "Odbijena";
                    tv.Komentar = "Posiljalac nije imao dovoljno stanja na racunu!";
                }
                if (tv.TipTransakcije != "Isplata")
                {
                    if (primalac.Klijent is FizickoLice)
                    {
                        FizickoLice fl = await session.GetAsync<FizickoLice>(primalac.Klijent.ID);

                        string imePrezime = $"{fl.Ime ?? ""} {fl.Prezime ?? ""}".Trim();
                        if (imePrezime != tv.PodaciOPrimaocu)
                            return "Uneti podaci o primaocu se ne poklapaju sa imenom i prezimenom vlasnika racuna!".ToError(400);
                    }
                    else if (primalac.Klijent is PravnoLice) {
                        PravnoLice pl = await session.GetAsync<PravnoLice>(primalac.Klijent.ID);

                        if (pl.NazivFirme != tv.PodaciOPrimaocu)
                            return "Uneti podaci o primaocu se ne poklapaju sa nazivom firme vlasnika racuna!".ToError(400);
                    }

                    if (tv.TipTransakcije == "Konverzija" &&
                        posiljalac.Klijent.ID != primalac.Klijent.ID)
                        return "Racuni ne pripadaju istom klijentu!".ToError(400);

                    if (tv.Status == "Odobrena")
                    {
                        primalac.TrenutnoStanje += iznosUValutiPrimaoca;
                        await session.UpdateAsync(primalac);
                    }
                }
                if (tv.Status == "Odobrena")
                {
                    posiljalac.TrenutnoStanje -= iznosUValutiPosiljaoca;
                    await session.UpdateAsync(posiljalac);
                }
            }

            posiljalac = posiljalac ?? primalac;

            Transakcija transakcija = new Transakcija();
            int maxKod = await session.Query<Transakcija>()
                .Where(t => t.Racun.BrojRacuna == posiljalac.BrojRacuna)
                .Select(t => (int?)t.KodTransakcije)
                .MaxAsync() ?? 0;

            transakcija.KodTransakcije = maxKod + 1;
            transakcija.Racun = posiljalac;
            transakcija.TipTransakcije = tv.TipTransakcije;
            transakcija.Referenca = tv.Referenca;
            transakcija.Iznos = tv.Iznos;
            transakcija.PodaciOPrimaocu = tv.PodaciOPrimaocu;
            transakcija.Komentar = tv.Komentar;
            transakcija.Valuta = tv.Valuta;
            transakcija.Opis = tv.Opis;
            transakcija.Status = tv.Status;
            transakcija.Vreme = tv.Vreme;
            transakcija.Datum = tv.Datum;
            transakcija.NaKojiRacun = primalac;

            await session.SaveAsync(transakcija);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
            {
                await transaction.RollbackAsync();
            }

            return $"Došlo je do greške prilikom obrade transakcije: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    public static async Task<Result<bool, ErrorMessage>> UpdateTransakcija(TransakcijeView tv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Transakcija t = await session.Query<Transakcija>()
                .FirstOrDefaultAsync(x => x.KodTransakcije == tv.KodTransakcije
                       && x.Racun.BrojRacuna == tv.BrojRacunaPosiljalac);

            if (t == null)
                return "Transakcija ne postoji.".ToError(404);
            if (tv.TipTransakcije != t.TipTransakcije)
                return "Ne moze se menjati tip transakcije!".ToError(400);
            if (tv.Status != t.Status)
                return "Ne moze se menjati status transakcije!".ToError(400);
            if (tv.Status == "Odbijena")
                return "Ne moze se menjati odbijena transakcija!".ToError(400);

            Racun? posiljalacStari = t.Racun ?? null;
            Racun? primalacStari = t.NaKojiRacun ?? null;
            Racun? posiljalacNovi = tv.BrojRacunaPosiljalac == null ? null : await session.GetAsync<Racun>(tv.BrojRacunaPosiljalac);
            Racun? primalacNovi = tv.BrojRacunaPrimalac == null ? null : await session.GetAsync<Racun>(tv.BrojRacunaPrimalac);

            if (posiljalacNovi != posiljalacStari || primalacNovi != primalacStari)
                return "Ne mogu se menjati posiljalac ni primalac!".ToError(400);
            if (tv.PodaciOPrimaocu != t.PodaciOPrimaocu)
                return "Ne mogu se menjati Podaci o Primaocu".ToError(400);

            if (tv.Iznos != t.Iznos || tv.Valuta != t.Valuta)
            {
                double iznosUValutiPosiljaoca = posiljalacNovi != null ? KonvertujValutu(tv.Iznos, tv.Valuta, posiljalacNovi.Valuta) : 0;
                double iznosUValutiPrimaoca = primalacNovi != null ? KonvertujValutu(tv.Iznos, tv.Valuta, primalacNovi.Valuta) : 0;
                double stariIznosUValutiPosiljaoca = posiljalacStari != null ? KonvertujValutu(t.Iznos, t.Valuta, posiljalacStari.Valuta) : 0;
                double stariIznosUValutiPrimaoca = primalacStari != null ? KonvertujValutu(t.Iznos, t.Valuta, primalacStari.Valuta) : 0;

                // 1 Kao na bankomatu unosi se samo BrojRacunaPrimalaca i tu se dodaje
                if (tv.TipTransakcije == "Uplata")
                {
                    primalacNovi.TrenutnoStanje = primalacNovi.TrenutnoStanje + iznosUValutiPrimaoca - stariIznosUValutiPrimaoca;
                    await session.UpdateAsync(primalacNovi);
                }
                // 2 Kao na bankomatu unosti se samo BrojRacunaPosiljaoca i odatle se skida
                else
                {
                    if (posiljalacNovi.TrenutnoStanje - iznosUValutiPosiljaoca + stariIznosUValutiPosiljaoca < -posiljalacNovi.DozvoljeniMinus)
                        return "Nije moguce uciniti iznemu, posiljalac ce otici u nedozvoljeni minus!".ToError(400);

                    if (tv.TipTransakcije != "Isplata")
                    {
                        primalacNovi.TrenutnoStanje = primalacNovi.TrenutnoStanje + iznosUValutiPrimaoca - stariIznosUValutiPrimaoca;
                        await session.UpdateAsync(primalacNovi);
                    }

                    posiljalacNovi.TrenutnoStanje = posiljalacNovi.TrenutnoStanje - iznosUValutiPosiljaoca + stariIznosUValutiPosiljaoca;
                    await session.UpdateAsync(posiljalacNovi);
                }
            }

            posiljalacNovi = posiljalacNovi ?? primalacNovi;

            t.Referenca = tv.Referenca;
            t.Iznos = tv.Iznos;
            t.Komentar = tv.Komentar;
            t.Valuta = tv.Valuta;
            t.Opis = tv.Opis;
            t.Status = tv.Status;
            t.Vreme = tv.Vreme;
            t.Datum = tv.Datum;

            await session.SaveAsync(t);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
            {
                await transaction.RollbackAsync();
            }

            return $"Došlo je do greške prilikom obrade transakcije: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    public static async Task<Result<bool, ErrorMessage>> DeleteTransakcija(int kodTransakcije, string brojRacunaPosiljaoca)
    {
        ISession session = null;
        ITransaction transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Transakcija t = await session.Query<Transakcija>()
                .FirstOrDefaultAsync(x => x.KodTransakcije == kodTransakcije
                                       && x.Racun.BrojRacuna == brojRacunaPosiljaoca);
            if (t == null)
                return "Transakcija ne postoji.".ToError(404);

            await session.DeleteAsync(t);

            await transaction.CommitAsync();

            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
            {
                await transaction.RollbackAsync();
            }

            return $"Došlo je do greške prilikom obrade transakcije: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    #endregion
}
