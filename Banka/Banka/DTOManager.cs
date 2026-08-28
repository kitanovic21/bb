using Banka.DTOs;
using Banka.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Linq;

namespace Banka
{
    public class DTOManager
    {
        public static List<KlijentPregled> GetKlijentInfos()
        {
            List<KlijentPregled> klijentInfos = new List<KlijentPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    IEnumerable<Klijent> klijenti =
                        from k in session.Query<Klijent>()
                        select k;

                    foreach (Klijent k in klijenti)
                    {
                        string imeNaziv = "";
                        string jmbgPib = "";

                        if (k is FizickoLice)
                        {
                            FizickoLice f = (FizickoLice)k;

                            imeNaziv = f.Ime + " " + f.Prezime;
                            jmbgPib = f.JMBG;
                        }
                        else if (k is PravnoLice)
                        {
                            PravnoLice p = (PravnoLice)k;

                            imeNaziv = p.NazivFirme;
                            jmbgPib = p.PIB;
                        }

                        string telefon = "";

                        if (k.Telefoni != null && k.Telefoni.Count > 0)
                        {
                            telefon = string.Join(", ", k.Telefoni.Select(t => t.BrojTelefona));
                        }

                        klijentInfos.Add(
                            new KlijentPregled(
                                k.ID,
                                k.TipKlijenta,
                                imeNaziv,
                                jmbgPib,
                                k.Grad,
                                telefon,
                                k.Status
                            )
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return klijentInfos;
        }

        public static async Task<KlijentBasic> GetKlijentBasic(int idKlijenta)
        {
            KlijentBasic kb = new KlijentBasic();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    Klijent k = await session.GetAsync<Klijent>(idKlijenta);

                    kb.KlijentId = k.ID;
                    kb.TipKlijenta = k.TipKlijenta;
                    kb.Status = k.Status;
                    kb.Adresa = k.Adresa;
                    kb.Grad = k.Grad;
                    kb.Email = k.Email;
                    kb.Komentar = k.Komentar;

                    if (k.Telefoni != null && k.Telefoni.Count > 0)
                    {
                        kb.Telefon = string.Join(", ", k.Telefoni.Select(t => t.BrojTelefona));
                    }

                    if (k is FizickoLice)
                    {
                        FizickoLice f = (FizickoLice)k;

                        kb.Ime = f.Ime;
                        kb.Prezime = f.Prezime;
                        kb.JMBG = f.JMBG;
                        kb.BrojLicneKarte = f.BrojLicneKarte;
                        kb.DatumRodjenja = f.DatumRodjenja;
                    }
                    else if (k is PravnoLice)
                    {
                        PravnoLice p = (PravnoLice)k;

                        kb.NazivFirme = p.NazivFirme;
                        kb.PIB = p.PIB;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return kb;
        }

        public static async Task<bool> AddKlijent(KlijentBasic kb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Klijent klijent;

                if (kb.TipKlijenta == "fizicko")
                {
                    FizickoLice f = new FizickoLice();

                    f.TipKlijenta = "fizicko";
                    f.Status = kb.Status;
                    f.Adresa = kb.Adresa;
                    f.Grad = kb.Grad;
                    f.Email = kb.Email;
                    f.Komentar = kb.Komentar;

                    f.Ime = kb.Ime;
                    f.Prezime = kb.Prezime;
                    f.JMBG = kb.JMBG;
                    f.BrojLicneKarte = kb.BrojLicneKarte;

                    if (kb.DatumRodjenja.HasValue)
                        f.DatumRodjenja = kb.DatumRodjenja.Value;

                    klijent = f;
                }
                else
                {
                    PravnoLice p = new PravnoLice();

                    p.TipKlijenta = "pravno";
                    p.Status = kb.Status;
                    p.Adresa = kb.Adresa;
                    p.Grad = kb.Grad;
                    p.Email = kb.Email;
                    p.Komentar = kb.Komentar;

                    p.NazivFirme = kb.NazivFirme;
                    p.PIB = kb.PIB;

                    klijent = p;
                }

                await session.SaveAsync(klijent);

                if (!string.IsNullOrWhiteSpace(kb.Telefon))
                {
                    string[] telefoni = kb.Telefon.Split(',');

                    foreach (string broj in telefoni)
                    {
                        string telefon = broj.Trim();

                        if (telefon.Length == 0)
                            continue;

                        TelefonKlijenta tk = new TelefonKlijenta();

                        tk.Klijent = klijent;
                        tk.BrojTelefona = telefon;

                        await session.SaveAsync(tk);
                    }
                }

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> UpdateKlijentBasic(KlijentBasic kb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || kb == null)
                    return false;

                transaction = session.BeginTransaction();

                Klijent k = await session.GetAsync<Klijent>(kb.KlijentId);
                if (k == null)
                    return false;

                k.Status = kb.Status;
                k.Adresa = kb.Adresa;
                k.Grad = kb.Grad;
                k.Email = kb.Email;
                k.Komentar = kb.Komentar;

                if (k is FizickoLice)
                {
                    FizickoLice f = (FizickoLice)k;

                    f.Ime = kb.Ime;
                    f.Prezime = kb.Prezime;
                    f.JMBG = kb.JMBG;
                    f.BrojLicneKarte = kb.BrojLicneKarte;

                    if (kb.DatumRodjenja.HasValue)
                        f.DatumRodjenja = kb.DatumRodjenja.Value;
                }
                else if (k is PravnoLice)
                {
                    PravnoLice p = (PravnoLice)k;

                    p.NazivFirme = kb.NazivFirme;
                    p.PIB = kb.PIB;
                }

                k.Telefoni.Clear();

                if (!string.IsNullOrWhiteSpace(kb.Telefon))
                {
                    string[] telefoni = kb.Telefon.Split(',');

                    foreach (string broj in telefoni)
                    {
                        string telefon = broj.Trim();

                        if (telefon.Length == 0)
                            continue;

                        if (k.Telefoni.Any(t => t.BrojTelefona == telefon))
                            continue;

                        TelefonKlijenta tk = new TelefonKlijenta();

                        tk.Klijent = k;
                        tk.BrojTelefona = telefon;

                        k.Telefoni.Add(tk);
                    }
                }

                await session.UpdateAsync(k);
                await session.FlushAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> DeleteKlijent(int idKlijenta)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Klijent k =
                    await session.GetAsync<Klijent>(idKlijenta);

                if (k == null)
                    return false;

                await session.DeleteAsync(k);

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static List<RacunPregled> GetRacunInfo()
        {
            List<RacunPregled> racunInfo = new List<RacunPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    racunInfo = (from r in session.Query<Racun>()
                                 select new RacunPregled(
                                     r.BrojRacuna,
                                     r.TipRacuna ?? "",
                                     r.StatusRacuna ?? "",
                                     r.Valuta ?? "",
                                     r.Klijent is FizickoLice
                                         ? ((FizickoLice)r.Klijent).Ime + " " + ((FizickoLice)r.Klijent).Prezime
                                         : (r.Klijent is PravnoLice ? ((PravnoLice)r.Klijent).NazivFirme : ""),
                                     r.Klijent.ID
                                 )).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return racunInfo;
        }

        public static async Task<RacunBasic> GetRacunBasic(string brojRacuna)
        {
            RacunBasic rb = new RacunBasic();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    Racun r = await session.GetAsync<Racun>(brojRacuna);

                    if (r != null)
                    {
                        rb.BrojRacuna = r.BrojRacuna;
                        rb.TipRacuna = r.TipRacuna;
                        rb.Valuta = r.Valuta;
                        rb.TrenutnoStanje = r.TrenutnoStanje;
                        rb.DatumOtvaranja = r.DatumOtvaranja;
                        rb.StatusRacuna = r.StatusRacuna;
                        rb.KamatnaStopa = r.KamatnaStopa;
                        rb.DozvoljeniMinus = r.DozvoljeniMinus;
                        rb.Komentar = r.Komentar;

                        if (r.Klijent != null)
                        {
                            Type stvarniTipKlijenta = NHibernateUtil.GetClass(r.Klijent);

                            if (stvarniTipKlijenta == typeof(FizickoLice))
                            {
                                FizickoLice f = await session.GetAsync<FizickoLice>(r.Klijent.ID);
                                if (f != null)
                                {
                                    rb.Klijent = $"{f.Ime} {f.Prezime}";
                                }
                            }
                            else if (stvarniTipKlijenta == typeof(PravnoLice))
                            {
                                PravnoLice p = await session.GetAsync<PravnoLice>(r.Klijent.ID);
                                if (p != null)
                                {
                                    rb.Klijent = p.NazivFirme;
                                }
                            }
                        }

                        if (r is TekuciRacun tr)
                        {
                            rb.MogucnostPlatnihKartica = tr.MogucnostPlatnihKartica;
                            rb.MesecniLimitTransakcija = tr.MesecniLimitTransakcija;
                        }
                        else if (r is StedniRacun sr)
                        {
                            rb.MinimalniIznosZaOtvaranje = sr.MinimalniIznosZaOtvaranje;
                            rb.UsloviPodizanjaSredstava = sr.UsloviPodizanjaSredstava;
                            rb.Frekvencija = sr.Frekvencija;
                            rb.BonusiZaDugorocnuStednju = sr.BonusiZaDugorocnuStednju;
                        }
                        else if (r is DevizniRacun dr)
                        {
                            rb.NamenaDevizni = dr.Namena;
                            rb.OgranicenjaDeviznihPropisa = dr.OgranicenjaDeviznihPropisa;
                            rb.KursnaRazlikaKonverzije = dr.KursnaRazlikaKonverzije;
                        }
                        else if (r is ZiroRacun zr)
                        {
                            rb.NamenaZiro = zr.Namena;
                            rb.EBankarstvoZaFirme = zr.EBankarstvoZaFirme;
                            rb.LimitMasovnihPlacanja = zr.LimitMasovnihPlacanja;
                            rb.Integracija = zr.Integracija;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri učitavanju detalja računa: {ex.Message}");
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return rb;
        }
        public static async Task<bool> AddRacun(RacunBasic rb, int klijentId)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Klijent klijent = await session.GetAsync<Klijent>(klijentId);

                if (klijent == null)
                {
                    MessageBox.Show("Izabrani klijent ne postoji u bazi podataka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                PredmetObracuna po = new PredmetObracuna();
                await session.SaveAsync(po);

                Racun racun;
                string tip = rb.TipRacuna?.ToLower().Trim() ?? "";

                if (tip == "tekuci" || tip == "tekući")
                {
                    TekuciRacun tr = new TekuciRacun();
                    tr.MogucnostPlatnihKartica = rb.MogucnostPlatnihKartica;
                    tr.MesecniLimitTransakcija = rb.MesecniLimitTransakcija;
                    racun = tr;
                }
                else if (tip == "stedni" || tip == "štedni")
                {
                    StedniRacun sr = new StedniRacun();
                    sr.MinimalniIznosZaOtvaranje = rb.MinimalniIznosZaOtvaranje;
                    sr.UsloviPodizanjaSredstava = rb.UsloviPodizanjaSredstava;
                    sr.Frekvencija = rb.Frekvencija;
                    sr.BonusiZaDugorocnuStednju = rb.BonusiZaDugorocnuStednju;
                    racun = sr;
                }
                else if (tip == "devizni")
                {
                    DevizniRacun dr = new DevizniRacun();
                    dr.Namena = rb.NamenaDevizni;
                    dr.OgranicenjaDeviznihPropisa = rb.OgranicenjaDeviznihPropisa;
                    dr.KursnaRazlikaKonverzije = rb.KursnaRazlikaKonverzije;
                    racun = dr;
                }
                else if (tip == "ziro" || tip == "žiro")
                {
                    ZiroRacun zr = new ZiroRacun();
                    zr.Namena = rb.NamenaZiro;
                    zr.EBankarstvoZaFirme = rb.EBankarstvoZaFirme;
                    zr.LimitMasovnihPlacanja = rb.LimitMasovnihPlacanja;
                    zr.Integracija = rb.Integracija;
                    racun = zr;
                }
                else
                {
                    MessageBox.Show("Neispravan tip računa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                racun.BrojRacuna = rb.BrojRacuna;
                racun.TipRacuna = tip;
                racun.Valuta = rb.Valuta;
                racun.TrenutnoStanje = rb.TrenutnoStanje;
                racun.DatumOtvaranja = rb.DatumOtvaranja;
                racun.StatusRacuna = rb.StatusRacuna;
                racun.KamatnaStopa = rb.KamatnaStopa;
                racun.DozvoljeniMinus = rb.DozvoljeniMinus;
                racun.Komentar = rb.Komentar;

                
                racun.Klijent = klijent;
                racun.PredmetObracuna = po;
                
                await session.SaveAsync(racun);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static List<TransakcijaPregled> GetTransakcijeInfos()
        {
            List<TransakcijaPregled> transakcijaInfo = new List<TransakcijaPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    transakcijaInfo = (from t in session.Query<Transakcija>()
                                 select new TransakcijaPregled(
                                     t.KodTransakcije,
                                     t.Racun.BrojRacuna ?? "",
                                     t.TipTransakcije ?? "",
                                     t.Valuta ?? "",
                                     t.Iznos,
                                     t.Status ?? "",
                                     t.Datum ?? DateTime.Today,
                                     t.Vreme ?? "",
                                     t.NaKojiRacun.BrojRacuna ?? ""
                                 )).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return transakcijaInfo;
        }

        public static async Task<TransakcijaBasic> GetTransakcijaBasic(int kodTransakcije, string brojRacuna)
        {
            TransakcijaBasic tb = new TransakcijaBasic();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    Transakcija t = await session.Query<Transakcija>()
                        .FirstOrDefaultAsync(x => x.KodTransakcije == kodTransakcije
                                               && x.Racun.BrojRacuna == brojRacuna);
                    tb.KodTransakcije = t.KodTransakcije;
                    tb.BrojRacunaPosiljalac = t.Racun != null ? t.Racun.BrojRacuna.ToString() : "";
                    tb.TipTransakcije = t.TipTransakcije;
                    tb.Referenca = t.Referenca;
                    tb.BrojRacunaPrimalac = t.NaKojiRacun != null ? t.NaKojiRacun.BrojRacuna.ToString() : "";
                    tb.Iznos = t.Iznos;
                    tb.PodacioOPrimaocu = t.PodaciOPrimaocu;
                    tb.Komentar=t.Komentar;
                    tb.Valuta=t.Valuta;
                    tb.Opis = t.Opis;
                    tb.Status  = t.Status;
                    tb.Datum=t.Datum;
                    tb.Vreme=t.Vreme;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return tb;
        }


        // SIGURNOSNA KONTROLA
        public static List<SigurnosnaKontrolaPregled> GetSigurnosneKontroleInfos()
        {
            List<SigurnosnaKontrolaPregled> kontrole = new List<SigurnosnaKontrolaPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    List<SigurnosnaKontrola> sveKontrole = session.Query<SigurnosnaKontrola>().ToList();

                    foreach (SigurnosnaKontrola sk in sveKontrole)
                    {
                        int klijentId = 0;
                        string klijentNaziv = "";
                        string brojRacuna = "";

                        if (sk.Klijent != null)
                        {
                            klijentId = sk.Klijent.ID;

                            Type tipKlijenta = NHibernateUtil.GetClass(sk.Klijent);

                            if (tipKlijenta == typeof(FizickoLice))
                            {
                                FizickoLice f = session.Get<FizickoLice>(sk.Klijent.ID);

                                if (f != null)
                                    klijentNaziv = f.Ime + " " + f.Prezime;
                            }
                            else if (tipKlijenta == typeof(PravnoLice))
                            {
                                PravnoLice p = session.Get<PravnoLice>(sk.Klijent.ID);

                                if (p != null)
                                    klijentNaziv = p.NazivFirme;
                            }
                        }

                        if (sk.Racun != null)
                            brojRacuna = sk.Racun.BrojRacuna;

                        kontrole.Add(
                            new SigurnosnaKontrolaPregled(
                                sk.Id,
                                klijentId,
                                klijentNaziv,
                                brojRacuna,
                                sk.TipDogadjaja ?? "",
                                sk.Datum,
                                sk.Vreme ?? "",
                                sk.IpAdresa ?? "",
                                sk.Status ?? ""
                            )
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Greška pri učitavanju sigurnosnih kontrola",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return kontrole;
        }

        public static async Task<bool> AddSigurnosnaKontrola(SigurnosnaKontrolaBasic sk)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Klijent klijent = await session.GetAsync<Klijent>(sk.KlijentId);
                Racun racun = await session.GetAsync<Racun>(sk.BrojRacuna);

                if (klijent == null)
                {
                    MessageBox.Show("Izabrani klijent ne postoji.");
                    return false;
                }

                if (racun == null)
                {
                    MessageBox.Show("Izabrani račun ne postoji.");
                    return false;
                }

                SigurnosnaKontrola kontrola = new SigurnosnaKontrola();

                kontrola.Klijent = klijent;
                kontrola.Racun = racun;
                kontrola.TipDogadjaja = sk.TipDogadjaja;
                kontrola.Datum = sk.Datum;
                kontrola.Vreme = sk.Vreme;
                kontrola.IpAdresa = sk.IpAdresa;
                kontrola.PodaciOUredjaju = sk.PodaciOUredjaju;
                kontrola.Status = sk.Status;
                kontrola.Opis = sk.Opis;

                await session.SaveAsync(kontrola);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }


        public static SigurnosnaKontrolaBasic GetSigurnosnaKontrolaBasic(int id)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                SigurnosnaKontrola sk =
                    session.Get<SigurnosnaKontrola>(id);

                if (sk == null)
                    return null;

                return new SigurnosnaKontrolaBasic
                {
                    Id = sk.Id,
                    KlijentId = sk.Klijent.ID,
                    BrojRacuna = sk.Racun.BrojRacuna,
                    TipDogadjaja = sk.TipDogadjaja,
                    Datum = sk.Datum,
                    Vreme = sk.Vreme,
                    IpAdresa = sk.IpAdresa,
                    PodaciOUredjaju = sk.PodaciOUredjaju,
                    Status = sk.Status,
                    Opis = sk.Opis
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return null;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> UpdateSigurnosnaKontrola(SigurnosnaKontrolaBasic skb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || skb == null)
                    return false;

                transaction = session.BeginTransaction();

                SigurnosnaKontrola sk = await session.GetAsync<SigurnosnaKontrola>(skb.Id);

                if (sk == null)
                    return false;

                Klijent klijent = await session.GetAsync<Klijent>(skb.KlijentId);
                Racun racun = await session.GetAsync<Racun>(skb.BrojRacuna);

                if (klijent == null || racun == null)
                    return false;

                sk.Klijent = klijent;
                sk.Racun = racun;
                sk.TipDogadjaja = skb.TipDogadjaja;
                sk.Datum = skb.Datum;
                sk.Vreme = skb.Vreme;
                sk.IpAdresa = skb.IpAdresa;
                sk.PodaciOUredjaju = skb.PodaciOUredjaju;
                sk.Status = skb.Status;
                sk.Opis = skb.Opis;

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(ex.GetBaseException().Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> DeleteSigurnosnaKontrola(int id)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                SigurnosnaKontrola sk = await session.GetAsync<SigurnosnaKontrola>(id);

                if (sk == null)
                    return false;

                await session.DeleteAsync(sk);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(ex.GetBaseException().Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }
        public static async Task<bool> AddTransakcija(TransakcijaBasic tb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                SigurnosnaKontrola sk = await session.GetAsync<SigurnosnaKontrola>(id);

                if (sk == null)
                    return false;

                await session.DeleteAsync(sk);
                Racun primalac = null;
                if(tb.TipTransakcije != "Isplata" && tb.TipTransakcije!= "Konverzija")
                {
                    primalac = await session.GetAsync<Racun>(tb.BrojRacunaPrimalac);
                    if (primalac == null)
                    {
                        MessageBox.Show("Izabrani primalac ne postoji.");
                        return false;
                    }
                    else 
                    {
                        if (primalac.Klijent.TipKlijenta == "fizicko")
                        {
                            FizickoLice fl = await session.GetAsync<FizickoLice>(primalac.Klijent.ID);
                            if (fl == null)
                                MessageBox.Show("Greska pri pribavljanju informacija o fizickom licu!");
                            else
                            {
                                string imePrezime = $"{fl.Ime ?? ""} {fl.Prezime ?? ""}".Trim();
                                if (imePrezime != tb.PodacioOPrimaocu)
                                    MessageBox.Show("Ime i prezime se ne poklapa sa vlasnikom racuna!");
                            }
                        }
                        else
                        {
                            PravnoLice pl = await session.GetAsync<PravnoLice>(primalac.Klijent.ID);
                            if(pl == null)
                                MessageBox.Show("Greska pri pribavljanju informacija o pravnom licu!");
                            else if(pl.NazivFirme != tb.PodacioOPrimaocu)
                                MessageBox.Show("Naziv firme se ne poklapa sa vlasnikom racuna!");
                        }
                    }
                }
                Racun posiljalac = await session.GetAsync<Racun>(tb.BrojRacunaPosiljalac);

                if (posiljalac == null)
                {
                    MessageBox.Show("Izabrani posiljalac ne postoji.");
                    return false;
                }

                Transakcija transakcija = new Transakcija();
                int maxKod = await session.Query<Transakcija>()
                    .Where(t => t.Racun.BrojRacuna == posiljalac.BrojRacuna)
                    .Select(t => (int?)t.KodTransakcije)
                    .MaxAsync() ?? 0;

                transakcija.KodTransakcije = maxKod + 1;

                transakcija.Racun = posiljalac;
                transakcija.TipTransakcije = tb.TipTransakcije;
                transakcija.Referenca = tb.Referenca;
                transakcija.Iznos = tb.Iznos;
                transakcija.PodaciOPrimaocu = tb.PodacioOPrimaocu;
                transakcija.Komentar = tb.Komentar;
                transakcija.Valuta = tb.Valuta;
                transakcija.Opis = tb.Opis;
                transakcija.Status = tb.Status;
                transakcija.Vreme = tb.Vreme;
                transakcija.Datum = tb.Datum;
                transakcija.NaKojiRacun = primalac;

                await session.SaveAsync(transakcija);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(ex.GetBaseException().Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> DeleteTransakcija(int kodTransakcije, string brojRacunaPosiljaoca)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Transakcija t = await session.Query<Transakcija>()
                    .FirstOrDefaultAsync(x => x.KodTransakcije == kodTransakcije
                                           && x.Racun.BrojRacuna == brojRacunaPosiljaoca);
                if (t == null)
                    return false;

                await session.DeleteAsync(t);

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> UpdateTransakcijaBasic(TransakcijaBasic tb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || tb == null)
                    return false;

                transaction = session.BeginTransaction();

                Transakcija t = await session.Query<Transakcija>()
                    .FirstOrDefaultAsync(x => x.KodTransakcije == tb.KodTransakcije
                                           && x.Racun.BrojRacuna == tb.BrojRacunaPosiljalac);

                if (t == null)
                    return false;
                Racun primalac = null;
                if (tb.TipTransakcije != "Isplata" && tb.TipTransakcije != "Konverzija")
                {
                    primalac = await session.GetAsync<Racun>(tb.BrojRacunaPrimalac);
                    if (primalac == null)
                    {
                        MessageBox.Show("Izabrani primalac ne postoji.");
                        return false;
                    }
                    else
                    {
                        if (primalac.Klijent.TipKlijenta == "fizicko")
                        {
                            FizickoLice fl = await session.GetAsync<FizickoLice>(primalac.Klijent.ID);
                            if (fl == null)
                                MessageBox.Show("Greska pri pribavljanju informacija o fizickom licu!");
                            else
                            {
                                string imePrezime = $"{fl.Ime ?? ""} {fl.Prezime ?? ""}".Trim();
                                if (imePrezime != tb.PodacioOPrimaocu)
                                    MessageBox.Show("Ime i prezime se ne poklapa sa vlasnikom racuna!");
                            }
                        }
                        else
                        {
                            PravnoLice pl = await session.GetAsync<PravnoLice>(primalac.Klijent.ID);
                            if (pl == null)
                                MessageBox.Show("Greska pri pribavljanju informacija o pravnom licu!");
                            else if (pl.NazivFirme != tb.PodacioOPrimaocu)
                                MessageBox.Show("Naziv firme se ne poklapa sa vlasnikom racuna!");
                        }
                    }
                }
                Racun posiljalac = await session.GetAsync<Racun>(tb.BrojRacunaPosiljalac);

                t.Racun = posiljalac;
                t.NaKojiRacun = primalac;
                t.TipTransakcije = tb.TipTransakcije;
                t.Referenca = tb.Referenca;
                t.Iznos = tb.Iznos;
                t.PodaciOPrimaocu = tb.PodacioOPrimaocu;
                t.Komentar = tb.Komentar;
                t.Valuta = tb.Valuta;
                t.Opis= tb.Opis;
                t.Status = tb.Status;
                t.Datum= tb.Datum;
                t.Vreme= tb.Vreme;

                await session.UpdateAsync(t);
                await session.FlushAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }
    }
}
