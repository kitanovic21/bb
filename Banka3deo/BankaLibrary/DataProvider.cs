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
    public static async Task<Result<TransakcijeView, ErrorMessage>> GetTransakcijaByID(int kodTransakcije, string brojRacuna) // DAJ BAS OVAJ
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

             var transakcija = await s.Query<Transakcija>()
                                 .FirstOrDefaultAsync(t => t.KodTransakcije == kodTransakcije && t.Racun.BrojRacuna == brojRacuna);

            if (transakcija == null)
            return $"Transakcija sa kodom {kodTransakcije} za račun {brojRacuna} nije pronađena.".ToError(404);

            return new TransakcijeView(transakcija);
        }
        catch (Exception ex)
        {
            //return "Došlo je do greške prilikom dohvatanja transakcije.".ToError(400);
            Console.WriteLine($"GREŠKA: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"DETALJI: {ex.InnerException.Message}");
            }
            // ili baci grešku dalje ka kontroleru:
            throw;
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

            await session.UpdateAsync(t);
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
    #region Klijenti
    public static async Task<Result<List<KlijentView>, ErrorMessage>> GetAllKlijenti() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await Task.Run(() => s.Query<Klijent>().ToList());

            List<KlijentView> klijenti = entiteti
                .Select(k => new KlijentView(k))
                .ToList();

            return klijenti;
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

    public static async Task<Result<KlijentView, ErrorMessage>> GetKlijentByID(int id) // DAJ BAS OVOG
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var klijent = await s.GetAsync<Klijent>(id);
            if (klijent == null)
                return $"Klijent sa ID-jem {id} nije pronađen.".ToError(404);

            return new KlijentView(klijent);
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

    public static async Task<Result<bool, ErrorMessage>> AddKlijent(KlijentView kv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Klijent klijent = kv.ToEntity();
            klijent.ID = 0; // ID generiše baza (Increment) - ignorišemo eventualno prosleđen ID

            await session.SaveAsync(klijent);
            await transaction.CommitAsync();

            kv.ID = klijent.ID;
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom dodavanja klijenta: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> UpdateKlijent(KlijentView kv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Klijent k = await session.GetAsync<Klijent>(kv.ID);
            if (k == null)
                return "Klijent ne postoji.".ToError(404);

            if (kv.TipKlijenta != k.TipKlijenta)
                return "Ne može se menjati tip klijenta!".ToError(400);

            k.Status = kv.Status;
            k.Adresa = kv.Adresa;
            k.Grad = kv.Grad;
            k.Email = kv.Email;
            k.Komentar = kv.Komentar;

            switch (k)
            {
                case FizickoLice fl:
                    fl.Ime = kv.Ime;
                    fl.Prezime = kv.Prezime;
                    fl.BrojLicneKarte = kv.BrojLicneKarte;
                    fl.JMBG = kv.JMBG;
                    fl.DatumRodjenja = kv.DatumRodjenja ?? fl.DatumRodjenja;
                    break;
                case PravnoLice pl:
                    pl.NazivFirme = kv.NazivFirme;
                    pl.PIB = kv.PIB;
                    break;
            }

            await session.UpdateAsync(k);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom izmene klijenta: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> DeleteKlijent(int id)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Klijent k = await session.GetAsync<Klijent>(id);
            if (k == null)
                return "Klijent ne postoji.".ToError(404);

            if (k.Racuni != null && k.Racuni.Any())
                return "Klijent ima otvorene račune, nije moguće obrisati ga.".ToError(400);

            await session.DeleteAsync(k);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom brisanja klijenta: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    #endregion

    #region Racuni
    public static async Task<Result<List<RacunView>, ErrorMessage>> GetAllRacuni() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await Task.Run(() => s.Query<Racun>().ToList());

            List<RacunView> racuni = entiteti
                .Select(r => new RacunView(r))
                .ToList();

            return racuni;
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

    public static async Task<Result<RacunView, ErrorMessage>> GetRacunByBroj(string brojRacuna) // DAJ BAS OVAJ
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var racun = await s.GetAsync<Racun>(brojRacuna);
            if (racun == null)
                return $"Račun sa brojem {brojRacuna} nije pronađen.".ToError(404);

            return new RacunView(racun);
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

    public static async Task<Result<List<RacunView>, ErrorMessage>> GetRacuniByKlijentID(int klijentId) // SVI RACUNI JEDNOG KLIJENTA
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var racuni = await s.Query<Racun>()
                .Where(r => r.Klijent.ID == klijentId)
                .ToListAsync();

            List<RacunView> data = racuni.Select(r => new RacunView(r)).ToList();
            return data;
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

    public static async Task<Result<bool, ErrorMessage>> AddRacun(RacunView rv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            if (string.IsNullOrWhiteSpace(rv.BrojRacuna))
                return "Broj računa je obavezan.".ToError(400);

            transaction = session.BeginTransaction();

            var postojeci = await session.GetAsync<Racun>(rv.BrojRacuna);
            if (postojeci != null)
                return "Račun sa tim brojem već postoji.".ToError(400);

            Klijent? klijent = await session.GetAsync<Klijent>(rv.KlijentID);
            if (klijent == null)
                return "Klijent za koji se otvara račun ne postoji.".ToError(404);

            Racun racun = rv.ToEntity();
            racun.Klijent = klijent;

            if (rv.PredmetObracunaID.HasValue)
            {
                racun.PredmetObracuna = await session.GetAsync<PredmetObracuna>(rv.PredmetObracunaID.Value);
            }
            else
            {
                PredmetObracuna po = new PredmetObracuna();
                await session.SaveAsync(po);
                racun.PredmetObracuna = po;
            }
            

            await session.SaveAsync(racun);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom otvaranja računa: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> UpdateRacun(RacunView rv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Racun r = await session.GetAsync<Racun>(rv.BrojRacuna);
            if (r == null)
                return "Račun ne postoji.".ToError(404);

            if (rv.TipRacuna != r.TipRacuna)
                return "Ne može se menjati tip računa!".ToError(400);
            if (rv.KlijentID != (r.Klijent?.ID ?? 0))
                return "Ne može se menjati vlasnik računa!".ToError(400);

            r.StatusRacuna = rv.StatusRacuna;
            r.DozvoljeniMinus = rv.DozvoljeniMinus;
            r.Valuta = rv.Valuta;
            r.Komentar = rv.Komentar;
            r.KamatnaStopa = rv.KamatnaStopa;

            switch (r)
            {
                case TekuciRacun tr:
                    tr.MogucnostPlatnihKartica = rv.MogucnostPlatnihKartica;
                    tr.MesecniLimitTransakcija = rv.MesecniLimitTransakcija;
                    break;
                case StedniRacun sr:
                    sr.MinimalniIznosZaOtvaranje = rv.MinimalniIznosZaOtvaranje ?? sr.MinimalniIznosZaOtvaranje;
                    sr.UsloviPodizanjaSredstava = rv.UsloviPodizanjaSredstava;
                    sr.Frekvencija = rv.Frekvencija;
                    sr.BonusiZaDugorocnuStednju = rv.BonusiZaDugorocnuStednju;
                    break;
                case DevizniRacun dr:
                    dr.Namena = rv.Namena;
                    dr.OgranicenjaDeviznihPropisa = rv.OgranicenjaDeviznihPropisa;
                    dr.KursnaRazlikaKonverzije = rv.KursnaRazlikaKonverzije;
                    break;
                case ZiroRacun zr:
                    zr.Namena = rv.Namena;
                    zr.EBankarstvoZaFirme = rv.EBankarstvoZaFirme;
                    zr.LimitMasovnihPlacanja = rv.LimitMasovnihPlacanja;
                    zr.Integracija = rv.Integracija;
                    break;
            }

            await session.UpdateAsync(r);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom izmene računa: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> DeleteRacun(string brojRacuna)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Racun r = await session.GetAsync<Racun>(brojRacuna);
            if (r == null)
                return "Račun ne postoji.".ToError(404);

            if (r.TrenutnoStanje != 0)
                return "Nije moguće obrisati račun koji nema nulto stanje.".ToError(400);

            var brojTransakcija = await session.Query<Transakcija>()
                .Where(t => t.Racun.BrojRacuna == brojRacuna || t.NaKojiRacun.BrojRacuna == brojRacuna)
                .CountAsync();
            if (brojTransakcija > 0)
                return "Nije moguće obrisati račun koji ima transakcije.".ToError(400);

            await session.DeleteAsync(r);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom brisanja računa: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    #endregion
    #region Krediti
    public static async Task<Result<List<KreditView>, ErrorMessage>> GetAllKrediti() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await s.QueryOver<Kredit>()
                .Fetch(SelectMode.Fetch, k => k.Klijent)
                .Fetch(SelectMode.Fetch, k => k.Racun)
                .ListAsync();

            List<KreditView> krediti = entiteti
                .Select(k => new KreditView(k))
                .ToList();

            return krediti;
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

    public static async Task<Result<KreditView, ErrorMessage>> GetKreditByID(int id) // DAJ BAS OVAJ
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var kredit = await s.GetAsync<Kredit>(id);
            if (kredit == null)
                return $"Kredit sa ID-jem {id} nije pronađen.".ToError(404);

            return new KreditView(kredit);
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

    public static async Task<Result<List<KreditView>, ErrorMessage>> GetKreditiByKlijentID(int klijentId) // SVI KREDITI JEDNOG KLIJENTA
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var krediti = await s.Query<Kredit>()
                .Where(k => k.Klijent.ID == klijentId)
                .ToListAsync();

            List<KreditView> data = krediti.Select(k => new KreditView(k)).ToList();
            return data;
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

    public static async Task<Result<bool, ErrorMessage>> AddKredit(KreditView kv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Klijent? klijent = await session.GetAsync<Klijent>(kv.KlijentID);
            if (klijent == null)
                return "Klijent za koga se odobrava kredit ne postoji.".ToError(404);

            Racun? racun = await session.GetAsync<Racun>(kv.BrojRacuna);
            if (racun == null)
                return "Račun na koji se odobrava kredit ne postoji.".ToError(404);

            PredmetObracuna? predmetObracuna = await session.GetAsync<PredmetObracuna>(kv.PredmetObracunaID);
            if (predmetObracuna == null)
                return "Predmet obračuna za kredit ne postoji.".ToError(404);

            Kredit kredit = kv.ToEntity();
            kredit.Id = 0; // ID generiše baza (Identity) - ignorišemo eventualno prosleđen ID
            kredit.Klijent = klijent;
            kredit.Racun = racun;
            kredit.PredmetObracuna = predmetObracuna;

            await session.SaveAsync(kredit);
            await transaction.CommitAsync();

            kv.Id = kredit.Id;
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom dodavanja kredita: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> UpdateKredit(KreditView kv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Kredit k = await session.GetAsync<Kredit>(kv.Id);
            if (k == null)
                return "Kredit ne postoji.".ToError(404);

            if (kv.KlijentID != (k.Klijent?.ID ?? 0))
                return "Ne može se menjati klijent kredita!".ToError(400);
            if (kv.BrojRacuna != (k.Racun?.BrojRacuna ?? string.Empty))
                return "Ne može se menjati račun na koji je kredit odobren!".ToError(400);
            if (kv.PredmetObracunaID != (k.PredmetObracuna?.ID ?? 0))
                return "Ne može se menjati predmet obračuna kredita!".ToError(400);

            k.StatusKredita = kv.StatusKredita;
            k.Namena = kv.Namena;
            k.Komentar = kv.Komentar;
            k.Iznos = kv.Iznos;
            k.Valuta = kv.Valuta;
            k.KamatnaStopa = kv.KamatnaStopa;
            k.RokOtplate = kv.RokOtplate;
            k.MesecnaRata = kv.MesecnaRata;
            k.DatumDospeca = kv.DatumDospeca;

            await session.UpdateAsync(k);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom izmene kredita: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> DeleteKredit(int id)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Kredit k = await session.GetAsync<Kredit>(id);
            if (k == null)
                return "Kredit ne postoji.".ToError(404);

            await session.DeleteAsync(k);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom brisanja kredita: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    #endregion

    #region Kamate
    public static async Task<Result<List<KamataView>, ErrorMessage>> GetAllKamate() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await Task.Run(() => s.Query<Kamata>().ToList());

            List<KamataView> kamate = entiteti
                .Select(k => new KamataView(k))
                .ToList();

            return kamate;
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

    public static async Task<Result<KamataView, ErrorMessage>> GetKamataByID(int id) // DAJ BAS OVU
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var kamata = await s.GetAsync<Kamata>(id);
            if (kamata == null)
                return $"Kamata sa ID-jem {id} nije pronađena.".ToError(404);

            return new KamataView(kamata);
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

    public static async Task<Result<List<KamataView>, ErrorMessage>> GetKamateByPredmetObracunaID(int predmetObracunaId) // SVE KAMATE ZA JEDAN PREDMET OBRAČUNA (kredit/depozit/račun)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var kamate = await s.Query<Kamata>()
                .Where(k => k.PredmetObracuna.ID == predmetObracunaId)
                .ToListAsync();

            List<KamataView> data = kamate.Select(k => new KamataView(k)).ToList();
            return data;
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

    public static async Task<Result<bool, ErrorMessage>> AddKamata(KamataView kv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            PredmetObracuna? predmetObracuna = await session.GetAsync<PredmetObracuna>(kv.PredmetObracunaID);
            if (predmetObracuna == null)
            {
                predmetObracuna = new PredmetObracuna();
                await session.SaveAsync(predmetObracuna);
            }
                

            Kamata kamata = kv.ToEntity();
            kamata.Id = 0; // ID generiše baza (Increment) - ignorišemo eventualno prosleđen ID
            kamata.PredmetObracuna = predmetObracuna;

            await session.SaveAsync(kamata);
            await transaction.CommitAsync();

            kv.Id = kamata.Id;
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom dodavanja kamate: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> UpdateKamata(KamataView kv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Kamata k = await session.GetAsync<Kamata>(kv.Id);
            if (k == null)
                return "Kamata ne postoji.".ToError(404);

            if (kv.PredmetObracunaID != (k.PredmetObracuna?.ID ?? 0))
                return "Ne može se menjati predmet obračuna kamate!".ToError(400);

            k.Status = kv.Status;
            k.TipKamate = kv.TipKamate;
            k.DatumObracuna = kv.DatumObracuna;
            k.PeriodObracuna = kv.PeriodObracuna;
            k.IznosKamate = kv.IznosKamate;

            await session.UpdateAsync(k);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom izmene kamate: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> DeleteKamata(int id)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Kamata k = await session.GetAsync<Kamata>(id);
            if (k == null)
                return "Kamata ne postoji.".ToError(404);

            await session.DeleteAsync(k);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom brisanja kamate: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    #endregion

    #region Depoziti
    public static async Task<Result<List<DepozitView>, ErrorMessage>> GetAllDepoziti() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await s.QueryOver<Depozit>()
                .Fetch(SelectMode.Fetch, d => d.Klijent)
                .Fetch(SelectMode.Fetch, d => d.Racun)
                .ListAsync();

            List<DepozitView> depoziti = entiteti
                .Select(d => new DepozitView(d))
                .ToList();

            return depoziti;
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

    public static async Task<Result<DepozitView, ErrorMessage>> GetDepozitByID(int id) // DAJ BAS OVAJ
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var depozit = await s.GetAsync<Depozit>(id);
            if (depozit == null)
                return $"Depozit sa ID-jem {id} nije pronađen.".ToError(404);

            return new DepozitView(depozit);
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

    public static async Task<Result<List<DepozitView>, ErrorMessage>> GetDepozitiByKlijentID(int klijentId) // SVI DEPOZITI JEDNOG KLIJENTA
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var depoziti = await s.Query<Depozit>()
                .Where(d => d.Klijent.ID == klijentId)
                .ToListAsync();

            List<DepozitView> data = depoziti.Select(d => new DepozitView(d)).ToList();
            return data;
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

    public static async Task<Result<bool, ErrorMessage>> AddDepozit(DepozitView dv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Klijent? klijent = await session.GetAsync<Klijent>(dv.KlijentID);
            if (klijent == null)
                return "Klijent za koga se otvara depozit ne postoji.".ToError(404);

            PredmetObracuna? predmetObracuna = await session.GetAsync<PredmetObracuna>(dv.PredmetObracunaID);
            if (predmetObracuna == null)
            {
                predmetObracuna = new PredmetObracuna();
                await session.SaveAsync(predmetObracuna);
            }

            Racun? racun = null;
            if (!string.IsNullOrWhiteSpace(dv.BrojRacuna))
            {
                racun = await session.GetAsync<Racun>(dv.BrojRacuna);
                if (racun == null)
                    return "Račun povezan sa depozitom ne postoji.".ToError(404);
            }

            Depozit depozit = dv.ToEntity();
            depozit.Id = 0; // ID generiše baza (Identity) - ignorišemo eventualno prosleđen ID
            depozit.Klijent = klijent;
            depozit.PredmetObracuna = predmetObracuna;
            depozit.Racun = racun;

            await session.SaveAsync(depozit);
            await transaction.CommitAsync();

            dv.Id = depozit.Id;
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom dodavanja depozita: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> UpdateDepozit(DepozitView dv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Depozit d = await session.GetAsync<Depozit>(dv.Id);
            if (d == null)
                return "Depozit ne postoji.".ToError(404);

            if (dv.KlijentID != (d.Klijent?.ID ?? 0))
                return "Ne može se menjati klijent depozita!".ToError(400);
            if (dv.PredmetObracunaID != (d.PredmetObracuna?.ID ?? 0))
                return "Ne može se menjati predmet obračuna depozita!".ToError(400);
            if ((dv.BrojRacuna ?? string.Empty) != (d.Racun?.BrojRacuna ?? string.Empty))
                return "Ne može se menjati račun povezan sa depozitom!".ToError(400);

            d.Iznos = dv.Iznos;
            d.Komentar = dv.Komentar;
            d.PeriodOrocenja = dv.PeriodOrocenja;
            d.DatumPocetka = dv.DatumPocetka;
            d.Valuta = dv.Valuta;
            d.OcekivanaKamata = dv.OcekivanaKamata;
            d.DatumIsteka = dv.DatumIsteka;
            d.Status = dv.Status;
            d.KamatnaStopa = dv.KamatnaStopa;

            await session.UpdateAsync(d);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom izmene depozita: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> DeleteDepozit(int id)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Depozit d = await session.GetAsync<Depozit>(id);
            if (d == null)
                return "Depozit ne postoji.".ToError(404);

            await session.DeleteAsync(d);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom brisanja depozita: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }
    #endregion

    #region SigurnosnaKontrola
    public static async Task<Result<List<SigurnosnaKontrolaView>, ErrorMessage>> GetAllSigurnosnaKontrole() // DAJ SVE
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var entiteti = await s.QueryOver<SigurnosnaKontrola>()
                .Fetch(SelectMode.Fetch, sk => sk.Klijent)
                .Fetch(SelectMode.Fetch, sk => sk.Racun)
                .ListAsync();

            List<SigurnosnaKontrolaView> dogadjaji = entiteti
                .Select(sk => new SigurnosnaKontrolaView(sk))
                .ToList();

            return dogadjaji;
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

    public static async Task<Result<SigurnosnaKontrolaView, ErrorMessage>> GetSigurnosnaKontrolaByID(int id) // DAJ BAS OVAJ
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var dogadjaj = await s.GetAsync<SigurnosnaKontrola>(id);
            if (dogadjaj == null)
                return $"Događaj sigurnosne kontrole sa ID-jem {id} nije pronađen.".ToError(404);

            return new SigurnosnaKontrolaView(dogadjaj);
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

    public static async Task<Result<List<SigurnosnaKontrolaView>, ErrorMessage>> GetSigurnosnaKontroleByKlijentID(int klijentId) // SVI DOGAĐAJI JEDNOG KLIJENTA
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            var dogadjaji = await s.Query<SigurnosnaKontrola>()
                .Where(sk => sk.Klijent.ID == klijentId)
                .ToListAsync();

            List<SigurnosnaKontrolaView> data = dogadjaji.Select(sk => new SigurnosnaKontrolaView(sk)).ToList();
            return data;
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

    public static async Task<Result<bool, ErrorMessage>> AddSigurnosnaKontrola(SigurnosnaKontrolaView skv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            Klijent? klijent = null;
            if (skv.KlijentID.HasValue)
            {
                klijent = await session.GetAsync<Klijent>(skv.KlijentID.Value);
                if (klijent == null)
                    return "Klijent naveden u događaju sigurnosne kontrole ne postoji.".ToError(404);
            }

            Racun? racun = null;
            if (!string.IsNullOrWhiteSpace(skv.BrojRacuna))
            {
                racun = await session.GetAsync<Racun>(skv.BrojRacuna);
                if (racun == null)
                    return "Račun naveden u događaju sigurnosne kontrole ne postoji.".ToError(404);
            }

            SigurnosnaKontrola dogadjaj = skv.ToEntity();
            dogadjaj.Id = 0; // ID generiše baza (Increment) - ignorišemo eventualno prosleđen ID
            dogadjaj.Klijent = klijent;
            dogadjaj.Racun = racun;

            await session.SaveAsync(dogadjaj);
            await transaction.CommitAsync();

            skv.Id = dogadjaj.Id;
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom dodavanja događaja sigurnosne kontrole: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> UpdateSigurnosnaKontrola(SigurnosnaKontrolaView skv)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            SigurnosnaKontrola sk = await session.GetAsync<SigurnosnaKontrola>(skv.Id);
            if (sk == null)
                return "Događaj sigurnosne kontrole ne postoji.".ToError(404);

            if (skv.KlijentID != sk.Klijent?.ID)
                return "Ne može se menjati klijent povezan sa događajem!".ToError(400);
            if ((skv.BrojRacuna ?? string.Empty) != (sk.Racun?.BrojRacuna ?? string.Empty))
                return "Ne može se menjati račun povezan sa događajem!".ToError(400);

            sk.TipDogadjaja = skv.TipDogadjaja;
            sk.Opis = skv.Opis;
            sk.Status = skv.Status;
            sk.IpAdresa = skv.IpAdresa;
            sk.PodaciOUredjaju = skv.PodaciOUredjaju;
            sk.Datum = skv.Datum;
            sk.Vreme = skv.Vreme;

            await session.UpdateAsync(sk);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom izmene događaja sigurnosne kontrole: {ex.Message}".ToError(500);
        }
        finally
        {
            transaction?.Dispose();
            session?.Close();
            session?.Dispose();
        }
    }

    public static async Task<Result<bool, ErrorMessage>> DeleteSigurnosnaKontrola(int id)
    {
        ISession? session = null;
        ITransaction? transaction = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
                return "Nemoguće otvoriti sesiju.".ToError(403);

            transaction = session.BeginTransaction();

            SigurnosnaKontrola sk = await session.GetAsync<SigurnosnaKontrola>(id);
            if (sk == null)
                return "Događaj sigurnosne kontrole ne postoji.".ToError(404);

            await session.DeleteAsync(sk);
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            if (transaction != null && transaction.IsActive)
                await transaction.RollbackAsync();

            return $"Došlo je do greške prilikom brisanja događaja sigurnosne kontrole: {ex.Message}".ToError(500);
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
