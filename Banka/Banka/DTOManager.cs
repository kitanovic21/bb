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

        //                  RACUN

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

        public static async Task<bool> UpdateRacunBasic(RacunBasic rb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || rb == null || string.IsNullOrWhiteSpace(rb.BrojRacuna))
                    return false;

                transaction = session.BeginTransaction();

                Racun r = await session.GetAsync<Racun>(rb.BrojRacuna);
                if (r == null)
                    return false;

                r.TipRacuna = rb.TipRacuna;
                r.StatusRacuna = rb.StatusRacuna;
                r.DozvoljeniMinus = rb.DozvoljeniMinus;
                r.TrenutnoStanje = rb.TrenutnoStanje;
                r.Valuta = rb.Valuta;
                r.Komentar = rb.Komentar;
                r.DatumOtvaranja = rb.DatumOtvaranja;
                r.KamatnaStopa = rb.KamatnaStopa;

                if (r is TekuciRacun tekuci)
                {
                    tekuci.MogucnostPlatnihKartica = rb.MogucnostPlatnihKartica;
                    tekuci.MesecniLimitTransakcija = rb.MesecniLimitTransakcija;
                }
                else if (r is StedniRacun stedni)
                {
                    stedni.MinimalniIznosZaOtvaranje = rb.MinimalniIznosZaOtvaranje;
                    stedni.UsloviPodizanjaSredstava = rb.UsloviPodizanjaSredstava;
                    stedni.Frekvencija = rb.Frekvencija;
                    stedni.BonusiZaDugorocnuStednju = rb.BonusiZaDugorocnuStednju;
                }
                else if (r is DevizniRacun devizni)
                {
                    devizni.Namena = rb.NamenaDevizni;
                    devizni.OgranicenjaDeviznihPropisa = rb.OgranicenjaDeviznihPropisa;
                    devizni.KursnaRazlikaKonverzije = rb.KursnaRazlikaKonverzije;
                }
                else if (r is ZiroRacun ziro)
                {
                    ziro.Namena = rb.NamenaZiro;
                    ziro.EBankarstvoZaFirme = rb.EBankarstvoZaFirme;
                    ziro.LimitMasovnihPlacanja = rb.LimitMasovnihPlacanja;
                    ziro.Integracija = rb.Integracija;
                }

                await session.UpdateAsync(r);
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

        public static async Task<bool> DeleteRacun(string brojRacuna)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || string.IsNullOrWhiteSpace(brojRacuna))
                    return false;

                transaction = session.BeginTransaction();

                Racun r = await session.GetAsync<Racun>(brojRacuna);

                if (r == null)
                    return false;

                await session.DeleteAsync(r);

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

        //TRANSAKCIJE

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
                    tb.Komentar = t.Komentar;
                    tb.Valuta = t.Valuta;
                    tb.Opis = t.Opis;
                    tb.Status = t.Status;
                    tb.Datum = t.Datum;
                    tb.Vreme = t.Vreme;

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
        public static async Task<bool> AddTransakcija(TransakcijaBasic tb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (!(session?.IsConnected ?? false))
                { 
                    MessageBox.Show("Nemoguće otvoriti sesiju.");
                    return false;
                }

                transaction = session.BeginTransaction();

                Racun posiljalac = tb.BrojRacunaPosiljalac == null ? null : await session.GetAsync<Racun>(tb.BrojRacunaPosiljalac);
                Racun primalac = tb.BrojRacunaPrimalac == null ? null : await session.GetAsync<Racun>(tb.BrojRacunaPrimalac);

                if (posiljalac == null && tb.TipTransakcije != "Uplata")
                {
                    MessageBox.Show("Izabrani posiljalac ne postoji.");
                    return false;
                }
                if (primalac == null && tb.TipTransakcije != "Isplata")
                {
                    MessageBox.Show("Račun primalaca ne postoji.");
                    return false;
                }

                double iznosUValutiPosiljaoca = posiljalac != null ? KonvertujValutu(tb.Iznos, tb.Valuta, posiljalac.Valuta) : 0;
                double iznosUValutiPrimaoca = primalac != null ? KonvertujValutu(tb.Iznos, tb.Valuta, primalac.Valuta) : 0;

                // 1 Kao na bankomatu unosi se samo BrojRacunaPrimalaca i tu se dodaje
                if (tb.TipTransakcije == "Uplata")
                {
                    if (tb.Status == "Odobrena")
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
                        tb.Status = "Odbijena";
                        tb.Komentar = "Posiljalac nije imao dovoljno stanja na racunu!";
                    }
                    if (tb.TipTransakcije != "Isplata")
                    {
                        if (primalac.Klijent is FizickoLice)
                        {
                            FizickoLice fl = await session.GetAsync<FizickoLice>(primalac.Klijent.ID);

                            string imePrezime = $"{fl.Ime ?? ""} {fl.Prezime ?? ""}".Trim();
                            if (imePrezime != tb.PodacioOPrimaocu)
                            {
                                MessageBox.Show("Uneti podaci o primaocu se ne poklapaju sa imenom i prezimenom vlasnika racuna!");
                                return false;
                            }
                        }
                        else if (primalac.Klijent is PravnoLice)
                        {
                            PravnoLice pl = await session.GetAsync<PravnoLice>(primalac.Klijent.ID);

                            if (pl.NazivFirme != tb.PodacioOPrimaocu)
                            {
                                MessageBox.Show("Uneti podaci o primaocu se ne poklapaju sa nazivom firme vlasnika racuna!");
                                return false;
                            }
                        }

                        if (tb.TipTransakcije == "Konverzija" &&
                            posiljalac.Klijent.ID != primalac.Klijent.ID)
                        {
                            MessageBox.Show("Racuni ne pripadaju istom klijentu!");
                            return false;
                        }

                        if (tb.Status == "Odobrena")
                        {
                            primalac.TrenutnoStanje += iznosUValutiPrimaoca;
                            await session.UpdateAsync(primalac);
                        }
                    }
                    if (tb.Status == "Odobrena")
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
                {
                    await transaction.RollbackAsync();
                }

                MessageBox.Show($"Došlo je do greške prilikom obrade transakcije: {ex.Message}");
                return false;
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
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

                if (!(session?.IsConnected ?? false))
                {
                    MessageBox.Show("Nemoguće otvoriti sesiju.");
                    return false;
                }

                transaction = session.BeginTransaction();

                Transakcija t = await session.Query<Transakcija>()
                    .FirstOrDefaultAsync(x => x.KodTransakcije == tb.KodTransakcije
                           && x.Racun.BrojRacuna == tb.BrojRacunaPosiljalac);

                if (t == null)
                {
                    MessageBox.Show("Transakcija ne postoji.");
                    return false;
                }
                if (tb.TipTransakcije != t.TipTransakcije)
                {
                    MessageBox.Show("Ne moze se menjati tip transakcije!");
                    return false;
                }
                if (tb.Status != t.Status)
                {
                    MessageBox.Show("Ne moze se menjati status transakcije!");
                    return false;
                }
                if (tb.Status == "Odbijena")
                {
                    MessageBox.Show("Ne moze se menjati odbijena transakcija!");
                    return false;
                }

                Racun posiljalacStari = t.Racun ?? null;
                Racun primalacStari = t.NaKojiRacun ?? null;
                Racun posiljalacNovi = tb.BrojRacunaPosiljalac == null ? null : await session.GetAsync<Racun>(tb.BrojRacunaPosiljalac);
                Racun primalacNovi = tb.BrojRacunaPrimalac == null ? null : await session.GetAsync<Racun>(tb.BrojRacunaPrimalac);

                if (posiljalacNovi != posiljalacStari || primalacNovi != primalacStari)
                {
                    MessageBox.Show("Ne mogu se menjati posiljalac ni primalac!");
                    return false;
                }
                if (tb.PodacioOPrimaocu != t.PodaciOPrimaocu)
                {
                    MessageBox.Show("Ne mogu se menjati Podaci o Primaocu");
                    return false;
                }

                if (tb.Iznos != t.Iznos || tb.Valuta != t.Valuta)
                {
                    double iznosUValutiPosiljaoca = posiljalacNovi != null ? KonvertujValutu(tb.Iznos, tb.Valuta, posiljalacNovi.Valuta) : 0;
                    double iznosUValutiPrimaoca = primalacNovi != null ? KonvertujValutu(tb.Iznos, tb.Valuta, primalacNovi.Valuta) : 0;
                    double stariIznosUValutiPosiljaoca = posiljalacStari != null ? KonvertujValutu(t.Iznos, t.Valuta, posiljalacStari.Valuta) : 0;
                    double stariIznosUValutiPrimaoca = primalacStari != null ? KonvertujValutu(t.Iznos, t.Valuta, primalacStari.Valuta) : 0;

                    // 1 Kao na bankomatu unosi se samo BrojRacunaPrimalaca i tu se dodaje
                    if (tb.TipTransakcije == "Uplata")
                    {
                        primalacNovi.TrenutnoStanje = primalacNovi.TrenutnoStanje + iznosUValutiPrimaoca - stariIznosUValutiPrimaoca;
                        await session.UpdateAsync(primalacNovi);
                    }
                    // 2 Kao na bankomatu unosti se samo BrojRacunaPosiljaoca i odatle se skida
                    else
                    {
                        if (posiljalacNovi.TrenutnoStanje - iznosUValutiPosiljaoca + stariIznosUValutiPosiljaoca < -posiljalacNovi.DozvoljeniMinus)
                        {
                            MessageBox.Show("Nije moguce uciniti iznemu, posiljalac ce otici u nedozvoljeni minus!");
                            return false;
                        }

                        if (tb.TipTransakcije != "Isplata")
                        {
                            primalacNovi.TrenutnoStanje = primalacNovi.TrenutnoStanje + iznosUValutiPrimaoca - stariIznosUValutiPrimaoca;
                            await session.UpdateAsync(primalacNovi);
                        }

                        posiljalacNovi.TrenutnoStanje = posiljalacNovi.TrenutnoStanje - iznosUValutiPosiljaoca + stariIznosUValutiPosiljaoca;
                        await session.UpdateAsync(posiljalacNovi);
                    }
                }

                posiljalacNovi = posiljalacNovi ?? primalacNovi;

                t.Referenca = tb.Referenca;
                t.Iznos = tb.Iznos;
                t.Komentar = tb.Komentar;
                t.Valuta = tb.Valuta;
                t.Opis = tb.Opis;
                t.Status = tb.Status;
                t.Vreme = tb.Vreme;
                t.Datum = tb.Datum;

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

                MessageBox.Show($"Došlo je do greške prilikom obrade transakcije: {ex.Message}");
                return false;
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }
        // KAMATA
        public static List<KamataPregled> GetKamateInfos()
        {
            List<KamataPregled> kamateInfo = new List<KamataPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    List<Kamata> kamate = session.Query<Kamata>().ToList();
                    List<Racun> racuni = session.Query<Racun>().ToList();
                    List<Kredit> krediti = session.Query<Kredit>().ToList();
                    List<Depozit> depoziti = session.Query<Depozit>().ToList();

                    foreach (Kamata k in kamate)
                    {
                        string predmetTip = "";
                        string konkretanPredmet = "";
                        int predmetId = k.PredmetObracuna.ID;

                        Racun racun = racuni.FirstOrDefault(r => r.PredmetObracuna != null && r.PredmetObracuna.ID == predmetId);

                        if (racun != null)
                        {
                            predmetTip = "Račun";
                            konkretanPredmet = racun.BrojRacuna;
                        }
                        else
                        {
                            Kredit kredit = krediti.FirstOrDefault(kr => kr.PredmetObracuna != null && kr.PredmetObracuna.ID == predmetId);

                            if (kredit != null)
                            {
                                predmetTip = "Kredit";
                                konkretanPredmet = "Kredit " + kredit.Id;
                            }
                            else
                            {
                                Depozit depozit = depoziti.FirstOrDefault(d => d.PredmetObracuna != null && d.PredmetObracuna.ID == predmetId);

                                if (depozit != null)
                                {
                                    predmetTip = "Depozit";
                                    konkretanPredmet = "Depozit " + depozit.Id;
                                }
                            }
                        }

                        KamataPregled kp = new KamataPregled();

                        kp.Id = k.Id;
                        kp.PredmetObracunaId = predmetId;
                        kp.PredmetTip = predmetTip;
                        kp.KonkretanPredmet = konkretanPredmet;
                        kp.TipKamate = k.TipKamate ?? "";
                        kp.IznosKamate = k.IznosKamate;
                        kp.PeriodObracuna = k.PeriodObracuna ?? "";
                        kp.DatumObracuna = k.DatumObracuna;
                        kp.Status = k.Status ?? "";

                        kamateInfo.Add(kp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Greška pri učitavanju kamata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return kamateInfo;
        }

        public static List<PredmetObracunaOpcija> GetPredmetiObracuna(string tip)
        {
            List<PredmetObracunaOpcija> predmeti = new List<PredmetObracunaOpcija>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return predmeti;

                if (tip == "Račun")
                {
                    List<Racun> racuni = session.Query<Racun>().ToList();

                    foreach (Racun r in racuni)
                    {
                        if (r.PredmetObracuna != null)
                            predmeti.Add(new PredmetObracunaOpcija(r.PredmetObracuna.ID, r.BrojRacuna));
                    }
                }
                else if (tip == "Kredit")
                {
                    List<Kredit> krediti = session.Query<Kredit>().ToList();

                    foreach (Kredit k in krediti)
                    {
                        if (k.PredmetObracuna != null)
                            predmeti.Add(new PredmetObracunaOpcija(
                                k.PredmetObracuna.ID,
                                "Kredit " + k.Id + " - " + k.Iznos.ToString("0.00") + " " + k.Valuta));
                    }
                }
                else if (tip == "Depozit")
                {
                    List<Depozit> depoziti = session.Query<Depozit>().ToList();

                    foreach (Depozit d in depoziti)
                    {
                        if (d.PredmetObracuna != null)
                            predmeti.Add(new PredmetObracunaOpcija(
                                d.PredmetObracuna.ID, 
                                "Depozit " + d.Id + " - " + d.Iznos.ToString("0.00") + " " + d.Valuta));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return predmeti;
        }

        public static async Task<bool> AddKamata(KamataBasic kb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || kb == null)
                    return false;

                transaction = session.BeginTransaction();

                PredmetObracuna predmet = await session.GetAsync<PredmetObracuna>(kb.PredmetObracunaId);

                if (predmet == null)
                    return false;

                Kamata kamata = new Kamata();

                kamata.PredmetObracuna = predmet;
                kamata.TipKamate = kb.TipKamate;
                kamata.IznosKamate = kb.IznosKamate;
                kamata.PeriodObracuna = kb.PeriodObracuna;
                kamata.DatumObracuna = kb.DatumObracuna;
                kamata.Status = kb.Status;

                await session.SaveAsync(kamata);
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
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> UpdateKamata(KamataBasic kb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || kb == null)
                    return false;

                transaction = session.BeginTransaction();

                Kamata kamata = await session.GetAsync<Kamata>(kb.Id);

                if (kamata == null)
                    return false;

                PredmetObracuna predmet = await session.GetAsync<PredmetObracuna>(kb.PredmetObracunaId);

                if (predmet == null)
                    return false;

                kamata.PredmetObracuna = predmet;
                kamata.TipKamate = kb.TipKamate;
                kamata.IznosKamate = kb.IznosKamate;
                kamata.PeriodObracuna = kb.PeriodObracuna;
                kamata.DatumObracuna = kb.DatumObracuna;
                kamata.Status = kb.Status;

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
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> DeleteKamata(int id)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Kamata kamata = await session.GetAsync<Kamata>(id);

                if (kamata == null)
                    return false;

                await session.DeleteAsync(kamata);
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
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        //DEPOZIT
        public static List<DepozitPregled> GetDepozitiInfos()
        {
            List<DepozitPregled> depozitiInfo = new List<DepozitPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    List<Depozit> depoziti = session.Query<Depozit>().ToList();

                    foreach (Depozit d in depoziti)
                    {
                        string klijentNaziv = "";

                        if (d.Klijent != null)
                        {
                            Type tipKlijenta = NHibernateUtil.GetClass(d.Klijent);

                            if (tipKlijenta == typeof(FizickoLice))
                            {
                                FizickoLice f = session.Get<FizickoLice>(d.Klijent.ID);

                                if (f != null)
                                    klijentNaziv = f.Ime + " " + f.Prezime;
                            }
                            else if (tipKlijenta == typeof(PravnoLice))
                            {
                                PravnoLice p = session.Get<PravnoLice>(d.Klijent.ID);

                                if (p != null)
                                    klijentNaziv = p.NazivFirme;
                            }
                        }

                        DepozitPregled dp = new DepozitPregled();

                        dp.Id = d.Id;
                        dp.KlijentId = d.Klijent != null ? d.Klijent.ID : 0;
                        dp.KlijentNaziv = klijentNaziv;
                        dp.Iznos = d.Iznos;
                        dp.DatumPocetka = d.DatumPocetka;
                        dp.Valuta = d.Valuta ?? "";
                        dp.Status = d.Status ?? "";

                        depozitiInfo.Add(dp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Greška pri učitavanju depozita", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (session != null)
                    session.Close();
            }

            return depozitiInfo;
        }

        public static DepozitBasic GetDepozitBasic(int id)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return null;

                Depozit d = session.Get<Depozit>(id);

                if (d == null)
                    return null;

                DepozitBasic db = new DepozitBasic();

                db.Id = d.Id;
                db.KlijentId = d.Klijent != null ? d.Klijent.ID : 0;
                db.BrojRacuna = d.Racun != null ? d.Racun.BrojRacuna : "";
                db.Iznos = d.Iznos;
                db.Komentar = d.Komentar ?? "";
                db.PeriodOrocenja = d.PeriodOrocenja;
                db.DatumPocetka = d.DatumPocetka;
                db.Valuta = d.Valuta ?? "";
                db.OcekivanaKamata = d.OcekivanaKamata;
                db.DatumIsteka = d.DatumIsteka;
                db.Status = d.Status ?? "";
                db.KamatnaStopa = d.KamatnaStopa;

                return db;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> AddDepozit(DepozitBasic db)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || db == null)
                    return false;

                transaction = session.BeginTransaction();

                Klijent klijent = await session.GetAsync<Klijent>(db.KlijentId);
                Racun racun = await session.GetAsync<Racun>(db.BrojRacuna);

                if (klijent == null || racun == null)
                    return false;

                PredmetObracuna predmet = new PredmetObracuna();
                await session.SaveAsync(predmet);

                Depozit depozit = new Depozit();

                depozit.Klijent = klijent;
                depozit.Racun = racun;
                depozit.PredmetObracuna = predmet;

                depozit.Iznos = db.Iznos;
                depozit.Komentar = db.Komentar;
                depozit.PeriodOrocenja = db.PeriodOrocenja;
                depozit.DatumPocetka = db.DatumPocetka;
                depozit.Valuta = db.Valuta;
                depozit.OcekivanaKamata = db.OcekivanaKamata;
                depozit.DatumIsteka = db.DatumIsteka;
                depozit.Status = db.Status;
                depozit.KamatnaStopa = db.KamatnaStopa;

                await session.SaveAsync(depozit);
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

        public static async Task<bool> UpdateDepozit(DepozitBasic db)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || db == null)
                    return false;

                transaction = session.BeginTransaction();

                Depozit depozit = await session.GetAsync<Depozit>(db.Id);

                if (depozit == null)
                    return false;

                Klijent klijent = await session.GetAsync<Klijent>(db.KlijentId);
                Racun racun = await session.GetAsync<Racun>(db.BrojRacuna);

                if (klijent == null || racun == null)
                    return false;

                depozit.Klijent = klijent;
                depozit.Racun = racun;
                depozit.Iznos = db.Iznos;
                depozit.Komentar = db.Komentar;
                depozit.PeriodOrocenja = db.PeriodOrocenja;
                depozit.DatumPocetka = db.DatumPocetka;
                depozit.Valuta = db.Valuta;
                depozit.OcekivanaKamata = db.OcekivanaKamata;
                depozit.DatumIsteka = db.DatumIsteka;
                depozit.Status = db.Status;
                depozit.KamatnaStopa = db.KamatnaStopa;

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

        public static async Task<bool> DeleteDepozit(int id)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Depozit depozit = await session.GetAsync<Depozit>(id);

                if (depozit == null)
                    return false;

                PredmetObracuna predmet = depozit.PredmetObracuna;

                await session.DeleteAsync(depozit);

                if (predmet != null)
                    await session.DeleteAsync(predmet);

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

        //KREDIT

        public static List<KreditPregled> GetKreditiInfos()
        {
            List<KreditPregled> kreditiInfo = new List<KreditPregled>();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    kreditiInfo = (from k in session.Query<Kredit>()
                                   select new KreditPregled(
                                       k.Id,
                                       k.StatusKredita,
                                       k.Namena,
                                       k.Iznos,
                                       k.Valuta,
                                       k.KamatnaStopa ?? 0,
                                       k.DatumDospeca ?? DateTime.MinValue,
                                       k.DatumOdobrenja,
                                       k.Racun,
                                       k.Klijent,
                                       k.MesecnaRata ?? 0
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

            return kreditiInfo;
        }
        public static async Task<KreditBasic> GetKreditBasic(int id)
        {
            KreditBasic kb = null;
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    // Da bi ovo radilo sam dodao using NHibernate.Linq;
                    // Bez ovoga ne bi mogo da imam sacuvano Racun ili Klijent
                    // nakon sto se zatvori session
                    Kredit k = await session.Query<Kredit>()
                                                        .Fetch(x => x.Klijent)
                                                        .Fetch(x => x.Racun)
                                                        .FirstOrDefaultAsync(x => x.Id == id);

                    if (k != null)
                    {
                        kb = new KreditBasic();

                        kb.Id = k.Id;
                        kb.StatusKredita = k.StatusKredita;
                        kb.Namena = k.Namena;
                        kb.Komentar = k.Komentar;
                        kb.Iznos = k.Iznos;
                        kb.Valuta = k.Valuta;
                        kb.KamatnaStopa = k.KamatnaStopa;
                        kb.RokOtplate = k.RokOtplate;
                        kb.MesecnaRata = k.MesecnaRata ?? 0;
                        kb.DatumDospeca = k.DatumDospeca;
                        kb.DatumOdobrenja = k.DatumOdobrenja;
                        kb.Racun = k.Racun;
                        kb.Klijent = k.Klijent;
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
        public static bool ProveriDaLiRacunPripadaKlijentu(string identificatorKlijenta, string brojRacuna)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null || string.IsNullOrEmpty(identificatorKlijenta) || string.IsNullOrEmpty(brojRacuna))
                    return false;

                return session.Query<Racun>()
                              .Any(r => r.BrojRacuna == brojRacuna &&
                                       ((r.Klijent is FizickoLice && ((FizickoLice)r.Klijent).JMBG == identificatorKlijenta) ||
                                        (r.Klijent is PravnoLice && ((PravnoLice)r.Klijent).PIB == identificatorKlijenta)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static double IzracunajMesecnuRatu(double iznos, double kamatnaStopa, int rokOtplate)
        {
            double r = (kamatnaStopa / 100.0) / 12.0; 
            double rata = iznos * (r * Math.Pow(1 + r, rokOtplate)) / (Math.Pow(1 + r, rokOtplate) - 1);
            return Math.Round(rata, 2); 
        }
        public static async Task<bool> AddKredit(KreditBasic kb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                if (session == null || kb == null)
                    return false;
                transaction = session.BeginTransaction();

                Racun racun = await session.Query<Racun>()
                                           .FirstOrDefaultAsync(r => r.BrojRacuna == kb.BrojRacuna);
                if (racun == null)
                {
                    MessageBox.Show("Izabrani račun ne postoji u bazi.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Klijent klijent = await session.Query<Klijent>()
                                               .FirstOrDefaultAsync(k => (k is FizickoLice && ((FizickoLice)k).JMBG == kb.KlijentIdentifikator) ||
                                                                         (k is PravnoLice && ((PravnoLice)k).PIB == kb.KlijentIdentifikator));
                if (klijent == null)
                {
                    MessageBox.Show("Izabrani klijent ne postoji u bazi.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Kredit kredit = new Kredit();

                kredit.StatusKredita = kb.StatusKredita;
                kredit.Namena = kb.Namena;
                kredit.Komentar = kb.Komentar;
                kredit.Iznos = kb.Iznos;
                kredit.Valuta = kb.Valuta;
                kredit.KamatnaStopa = kb.KamatnaStopa;
                kredit.RokOtplate = kb.RokOtplate;
                kredit.DatumOdobrenja = kb.DatumOdobrenja ?? DateTime.Now;
                if (kb.RokOtplate.HasValue && kb.RokOtplate.Value > 0)
                    kredit.DatumDospeca = kredit.DatumOdobrenja.AddMonths(kb.RokOtplate.Value);

                // ako se nesto sjebalo dobijam cu dobijem NaN jer cu delim sa 0
                double kStopa = kb.KamatnaStopa ?? 0;
                int rok = kb.RokOtplate ?? 0;

                kredit.MesecnaRata = IzracunajMesecnuRatu(kb.Iznos, kStopa, rok);

                PredmetObracuna predmet = new PredmetObracuna();
                await session.SaveAsync(predmet);

                kredit.Racun = racun;
                kredit.Klijent = klijent;
                kredit.PredmetObracuna = predmet;

                await session.SaveAsync(kredit);
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
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }

        public static async Task<bool> UpdateKredit(KreditBasic kb)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                if (session == null || kb == null)
                    return false;

                transaction = session.BeginTransaction();

                Kredit kredit = await session.GetAsync<Kredit>(kb.Id);
                if (kredit == null)
                {
                    MessageBox.Show("Kredit koji pokušavate da izmenite ne postoji u bazi.",
                                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Racun racun = await session.Query<Racun>()
                                           .FirstOrDefaultAsync(r => r.BrojRacuna == kb.BrojRacuna);
                if (racun == null)
                {
                    MessageBox.Show("Izabrani račun ne postoji u bazi.",
                                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Klijent klijent = await session.Query<Klijent>()
                                               .FirstOrDefaultAsync(k => (k is FizickoLice && ((FizickoLice)k).JMBG == kb.KlijentIdentifikator) ||
                                                                         (k is PravnoLice && ((PravnoLice)k).PIB == kb.KlijentIdentifikator));
                if (klijent == null)
                {
                    MessageBox.Show("Izabrani klijent ne postoji u bazi.",
                                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                kredit.StatusKredita = kb.StatusKredita;
                kredit.Namena = kb.Namena;
                kredit.Komentar = kb.Komentar;
                kredit.Iznos = kb.Iznos;
                kredit.Valuta = kb.Valuta;
                kredit.KamatnaStopa = kb.KamatnaStopa;
                kredit.RokOtplate = kb.RokOtplate;
                kredit.DatumOdobrenja = kb.DatumOdobrenja ?? kredit.DatumOdobrenja;

                if (kb.RokOtplate.HasValue && kb.RokOtplate.Value > 0)
                {
                    kredit.DatumDospeca = kredit.DatumOdobrenja.AddMonths(kb.RokOtplate.Value);
                }
                else
                {
                    kredit.DatumDospeca = null;
                }

                double kStopa = kb.KamatnaStopa ?? 0;
                int rok = kb.RokOtplate ?? 0;
                kredit.MesecnaRata = IzracunajMesecnuRatu(kb.Iznos, kStopa, rok);

                kredit.Racun = racun;
                kredit.Klijent = klijent;

                await session.UpdateAsync(kredit);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška pri izmeni",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (session != null)
                    session.Close();
            }
        }
        public static async Task<bool> DeleteKredit(int idKredita)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                if (session == null)
                    return false;

                transaction = session.BeginTransaction();

                Kredit kredit = await session.GetAsync<Kredit>(idKredita);

                if (kredit == null)
                {
                    MessageBox.Show("Izabrani kredit ne postoji u bazi.",
                                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var predmetObracuna = kredit.PredmetObracuna;

                if (predmetObracuna != null)
                {
                    int predmetId = predmetObracuna.ID;
                    Kamata kamata = await session.Query<Kamata>()
                                                 .FirstOrDefaultAsync(k => k.PredmetObracuna.ID == predmetId);

                    if (kamata != null)
                        await session.DeleteAsync(kamata);

                    await session.DeleteAsync(kredit);
                    await session.DeleteAsync(predmetObracuna);
                }
                else // ako nema predmetObracuna onda nema ni vezanu kamatu pa brisem samo kredit
                    await session.DeleteAsync(kredit);

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                MessageBox.Show(
                    ex.GetBaseException().Message,
                    "Greška pri brisanju kredita",
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