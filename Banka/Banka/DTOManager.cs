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
                                         : (r.Klijent is PravnoLice ? ((PravnoLice)r.Klijent).NazivFirme : "")
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
                    // Učitavamo račun iz baze po primarnom ključu
                    Racun r = await session.GetAsync<Racun>(brojRacuna);

                    if (r != null)
                    {
                        // 1. Osnovni podaci računa
                        rb.BrojRacuna = r.BrojRacuna;
                        rb.TipRacuna = r.TipRacuna;
                        rb.Valuta = r.Valuta;
                        rb.TrenutnoStanje = r.TrenutnoStanje;
                        rb.DatumOtvaranja = r.DatumOtvaranja;
                        rb.StatusRacuna = r.StatusRacuna;
                        rb.KamatnaStopa = r.KamatnaStopa;
                        rb.DozvoljeniMinus = r.DozvoljeniMinus;
                        rb.Komentar = r.Komentar;

                        // 2. Izvlačenje klijenta (Ime + Prezime ili Naziv firme)
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

                        // 3. Specifični podaci po podklasama računa
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
                                     t.Datum,
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

        public static async Task<TransakcijaBasic> GetTransakcijaBasic(int kodTransakcije)
        {
            TransakcijaBasic tb = new TransakcijaBasic();
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    Transakcija t = await session.Query<Transakcija>()
                                        .FirstOrDefaultAsync(x => x.KodTransakcije == kodTransakcije);
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

    }
}
