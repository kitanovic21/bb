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
    }
}
