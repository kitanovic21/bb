using Banka.DTOs;
using Banka.Entiteti;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Banka.Forme
{
    public partial class UcRacuni : UserControl
    {
        private List<RacunPregled> sviRacuni = new List<RacunPregled>();
        private string selektovaniRacun = null;
        private int? prosledjeniKlijentId = null;
        private string prosledjenoImeKlijenta = null;
        public UcRacuni()
        {
            InitializeComponent();

            cmbStatusFilter.SelectedIndex = 0;
            cmbStatusRacuna.SelectedIndex = 0;
            cmbTipFilter.SelectedIndex = 0;
            cmbTipRacuna.SelectedIndex = 0;

            btnNovi.Enabled = false;
            txtKlijent.Enabled = false;
            //cmbValuta.SelectedIndex = 0;
        }
        public UcRacuni(int? klijentId, string klijentImeNaziv) : this()
        {
            this.prosledjeniKlijentId = klijentId;
            this.prosledjenoImeKlijenta = klijentImeNaziv;

            txtPretraga.Text = klijentImeNaziv;

            btnNovi.Enabled = true;
        }

        private async void dgvRacuni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object vrednostId = dgvRacuni.Rows[e.RowIndex].Cells[0].Value;
            if (vrednostId == null)
                return;

                selektovaniRacun = vrednostId.ToString();

                cmbTipRacuna.Enabled = false;

                RacunBasic kb = await DTOManager.GetRacunBasic(selektovaniRacun);

                PopulateData(kb);
        }
        private void PopulateInfos()
        {
            sviRacuni = DTOManager.GetRacunInfo();

            PrimeniFiltere();
        }
        private static string UkloniKvacice(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            string lower = text.ToLower().Trim();

            return lower.Replace("š", "s")
                        .Replace("đ", "dj")
                        .Replace("č", "c")
                        .Replace("ć", "c")
                        .Replace("ž", "z");
        }
        private void PrimeniFiltere()
        {
            if (sviRacuni == null) return;

            string pretragaTekst = UkloniKvacice(txtPretraga.Text);
            string selektovaniTip = UkloniKvacice(cmbTipFilter.SelectedItem?.ToString());
            string selektovaniStatus = UkloniKvacice(cmbStatusFilter.SelectedItem?.ToString());

            var filtriraniRacuni = sviRacuni.Where(r =>
                (!prosledjeniKlijentId.HasValue || r.KlijentId == prosledjeniKlijentId.Value) &&

                (string.IsNullOrEmpty(pretragaTekst) ||
                 (r.BrojRacuna != null && UkloniKvacice(r.BrojRacuna).Contains(pretragaTekst)) ||
                 (r.ImeNaziv != null && UkloniKvacice(r.ImeNaziv).Contains(pretragaTekst))) &&

                (selektovaniTip.Contains("svi") || (r.TipRacuna != null && UkloniKvacice(r.TipRacuna).Contains(selektovaniTip))) &&

                (selektovaniStatus.Contains("svi") || (r.StatusRacuna != null && UkloniKvacice(r.StatusRacuna).Contains(selektovaniStatus)))
            ).ToList();

            dgvRacuni.Rows.Clear();

            foreach (RacunPregled rp in filtriraniRacuni)
            {
                dgvRacuni.Rows.Add(
                    rp.BrojRacuna,
                    rp.TipRacuna ?? "",
                    rp.StatusRacuna ?? "",
                    rp.Valuta ?? "",
                    rp.ImeNaziv ?? ""
                );
            }

            dgvRacuni.Refresh();
        }
        private void PopulateData(RacunBasic rb)
        {
            if (rb == null) return;

            txtKlijent.Text = rb.Klijent;
            txtBrojRacuna.Text = rb.BrojRacuna ?? "";
            txtValuta.Text = rb.Valuta ?? "";
            txtTrenutnoStanje.Text = rb.TrenutnoStanje.ToString();
            txtKamatnaStopa.Text = rb.KamatnaStopa.ToString();
            txtKomentar.Text = rb.Komentar ?? "";
            txtDozvoljeniMinus.Text = rb.DozvoljeniMinus.ToString();
            if (cmbStatusRacuna.Items.Contains(rb.StatusRacuna))
                cmbStatusRacuna.SelectedItem = rb.StatusRacuna;

            txtMesecniLimit.Clear();
            txtPaketiUsluga.Clear();
            txtMinimalniIznos.Clear();
            txtUsloviPodizanja.Clear();
            txtFrekvencija.Clear();
            txtBonusi.Clear();
            txtDozvoljeneValute.Clear();
            txtNamenaDevizni.Clear();
            txtKursnaRazlika.Clear();
            txtOgranicenja.Clear();
            txtNamenaZiro.Clear();
            txtLimitMasovnih.Clear();
            txtIntegracija.Clear();

            if (rb.TipRacuna == "tekuci")
            {
                cmbTipRacuna.SelectedItem = "Tekuci";
                tabTipRacuna.SelectedIndex = 0;
                chkPlatneKartice.Checked = (rb.MogucnostPlatnihKartica == "da");
                txtMesecniLimit.Text = rb.MesecniLimitTransakcija.ToString();
                txtPaketiUsluga.Text = "";
            }
            else if (rb.TipRacuna == "stedni")
            {
                cmbTipRacuna.SelectedItem = "Stedni";
                tabTipRacuna.SelectedIndex = 1;
                txtMinimalniIznos.Text = rb.MinimalniIznosZaOtvaranje.ToString();
                txtUsloviPodizanja.Text = rb.UsloviPodizanjaSredstava ?? "";
                txtFrekvencija.Text = rb.Frekvencija ?? "";
                txtBonusi.Text = rb.BonusiZaDugorocnuStednju.ToString();
            }
            else if (rb.TipRacuna == "devizni")
            {
                cmbTipRacuna.SelectedItem = "Devizni";
                tabTipRacuna.SelectedIndex = 2;
                txtDozvoljeneValute.Text = "";
                txtNamenaDevizni.Text = rb.NamenaDevizni ?? "";
                txtKursnaRazlika.Text = rb.KursnaRazlikaKonverzije.ToString();
                txtOgranicenja.Text = rb.OgranicenjaDeviznihPropisa ?? "";
            }
            else if (rb.TipRacuna == "ziro")
            {
                cmbTipRacuna.SelectedItem = "Ziro";
                tabTipRacuna.SelectedIndex = 3;
                txtNamenaZiro.Text = rb.NamenaZiro ?? "";
                txtLimitMasovnih.Text = rb.LimitMasovnihPlacanja.ToString();
                txtIntegracija.Text = rb.Integracija.ToString();
                chkEBankarstvo.Checked = (rb.EBankarstvoZaFirme == "da");
            }
        }

        private RacunBasic ProcitajPodatkeSaForme()
        {
            RacunBasic rb = new RacunBasic();

            rb.BrojRacuna = txtBrojRacuna.Text.Trim();
            rb.Klijent = txtKlijent.Text.Trim();
            rb.TipRacuna = UkloniKvacice(cmbTipRacuna.SelectedItem?.ToString()); rb.Valuta = txtValuta.Text.Trim();
            rb.StatusRacuna = cmbStatusRacuna.SelectedItem?.ToString();
            rb.DatumOtvaranja = dtpDatumOtvaranja.Value;
            rb.Komentar = txtKomentar.Text.Trim();

            if (double.TryParse(txtTrenutnoStanje.Text.Trim(), out double stanje))
                rb.TrenutnoStanje = stanje;

            if (double.TryParse(txtKamatnaStopa.Text.Trim(), out double kamata))
                rb.KamatnaStopa = kamata;
            else
                rb.KamatnaStopa = null;

            if (double.TryParse(txtDozvoljeniMinus.Text.Trim(), out double minus))
                rb.DozvoljeniMinus = minus;
            else
                rb.DozvoljeniMinus = null;

            string tip = rb.TipRacuna ?? "";

            if (tip == "tekuci" || tip == "tekući")
            {
                rb.MogucnostPlatnihKartica = chkPlatneKartice.Checked ? "da" : "ne";

                if (int.TryParse(txtMesecniLimit.Text.Trim(), out int limit))
                    rb.MesecniLimitTransakcija = limit;
                else
                    rb.MesecniLimitTransakcija = null;
            }
            else if (tip == "stedni" || tip == "štedni")
            {
                if (double.TryParse(txtMinimalniIznos.Text.Trim(), out double minIznos))
                    rb.MinimalniIznosZaOtvaranje = minIznos;

                rb.UsloviPodizanjaSredstava = txtUsloviPodizanja.Text.Trim();
                rb.Frekvencija = txtFrekvencija.Text.Trim();

                if (double.TryParse(txtBonusi.Text.Trim(), out double bonus))
                    rb.BonusiZaDugorocnuStednju = bonus;
                else
                    rb.BonusiZaDugorocnuStednju = null;
            }
            else if (tip == "devizni")
            {
                rb.NamenaDevizni = txtNamenaDevizni.Text.Trim();
                rb.OgranicenjaDeviznihPropisa = txtOgranicenja.Text.Trim();

                if (double.TryParse(txtKursnaRazlika.Text.Trim(), out double kursna))
                    rb.KursnaRazlikaKonverzije = kursna;
                else
                    rb.KursnaRazlikaKonverzije = null;
            }
            else if (tip == "ziro" || tip == "žiro")
            {
                rb.NamenaZiro = txtNamenaZiro.Text.Trim();
                rb.EBankarstvoZaFirme = chkEBankarstvo.Checked ? "da" : "ne";
                rb.Integracija = txtIntegracija.Text.Trim();

                if (double.TryParse(txtLimitMasovnih.Text.Trim(), out double limitMasovnih))
                    rb.LimitMasovnihPlacanja = limitMasovnih;
                else
                    rb.LimitMasovnihPlacanja = null;
            }

            return rb;
        }


        private void UcRacuni_Load_1(object sender, EventArgs e)
        {
            PopulateInfos();
        }
        private void OcistiFormu()
        {
            selektovaniRacun = null;

            dgvRacuni.ClearSelection();
            txtBrojRacuna.Clear();
            txtTrenutnoStanje.Clear();
            txtKamatnaStopa.Clear();
            txtKamatnaStopa.Clear();
            txtDozvoljeniMinus.Clear();
            txtKomentar.Clear();
            txtMesecniLimit.Clear();
            txtPaketiUsluga.Clear();
            txtMinimalniIznos.Clear();
            txtUsloviPodizanja.Clear();
            txtFrekvencija.Clear();
            txtBonusi.Clear();
            txtDozvoljeneValute.Clear();
            txtNamenaDevizni.Clear();
            txtKursnaRazlika.Clear();
            txtOgranicenja.Clear();
            txtNamenaZiro.Clear();
            txtLimitMasovnih.Clear();
            txtIntegracija.Clear();
            dtpDatumOtvaranja.Value = DateTime.Today;
            cmbTipRacuna.SelectedIndex = 0;
            cmbStatusRacuna.SelectedIndex = 0;
            chkPlatneKartice.Checked = false;
            chkEBankarstvo.Checked = false;

        }
        private bool ValidacijaRacuna()
        {
            if (string.IsNullOrWhiteSpace(txtBrojRacuna.Text))
            {
                MessageBox.Show("Molimo unesite broj računa.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBrojRacuna.Focus();
                return false;
            }

            if (cmbTipRacuna.SelectedItem == null || string.IsNullOrWhiteSpace(cmbTipRacuna.SelectedItem.ToString()))
            {
                MessageBox.Show("Molimo izaberite tip računa.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipRacuna.Focus();
                return false;
            }

            if (cmbStatusRacuna.SelectedItem == null || string.IsNullOrWhiteSpace(cmbStatusRacuna.SelectedItem.ToString()))
            {
                MessageBox.Show("Molimo izaberite status računa.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatusRacuna.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtValuta.Text))
            {
                MessageBox.Show("Molimo unesite valutu računa.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValuta.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtTrenutnoStanje.Text) && !double.TryParse(txtTrenutnoStanje.Text.Trim(), out _))
            {
                MessageBox.Show("Trenutno stanje mora biti ispravan broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrenutnoStanje.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtKamatnaStopa.Text) && !double.TryParse(txtKamatnaStopa.Text.Trim(), out _))
            {
                MessageBox.Show("Kamatna stopa mora biti ispravan broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKamatnaStopa.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtDozvoljeniMinus.Text) && !double.TryParse(txtDozvoljeniMinus.Text.Trim(), out _))
            {
                MessageBox.Show("Dozvoljeni minus mora biti ispravan broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDozvoljeniMinus.Focus();
                return false;
            }

            string tip = UkloniKvacice(cmbTipRacuna.SelectedItem.ToString());

            if (tip.Contains("teku"))
            {
                if (!string.IsNullOrWhiteSpace(txtMesecniLimit.Text) && !int.TryParse(txtMesecniLimit.Text.Trim(), out _))
                {
                    MessageBox.Show("Mesečni limit transakcija mora biti ceo broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMesecniLimit.Focus();
                    return false;
                }
            }
            else if (tip.Contains("sted"))
            {
                if (string.IsNullOrWhiteSpace(txtMinimalniIznos.Text) || !double.TryParse(txtMinimalniIznos.Text.Trim(), out _))
                {
                    MessageBox.Show("Minimalni iznos za otvaranje je obavezan i mora biti validan broj za štedni račun.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMinimalniIznos.Focus();
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(txtBonusi.Text) && !double.TryParse(txtBonusi.Text.Trim(), out _))
                {
                    MessageBox.Show("Bonusi moraju biti ispravan broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBonusi.Focus();
                    return false;
                }
            }
            else if (tip.Contains("deviz"))
            {
                if (!string.IsNullOrWhiteSpace(txtKursnaRazlika.Text) && !double.TryParse(txtKursnaRazlika.Text.Trim(), out _))
                {
                    MessageBox.Show("Kursna razlika mora biti ispravan broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKursnaRazlika.Focus();
                    return false;
                }
            }
            else if (tip.Contains("zir"))
            {
                if (!string.IsNullOrWhiteSpace(txtLimitMasovnih.Text) && !double.TryParse(txtLimitMasovnih.Text.Trim(), out _))
                {
                    MessageBox.Show("Limit masovnih plaćanja mora biti ispravan broj.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLimitMasovnih.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            if (!prosledjeniKlijentId.HasValue)
            {
                MessageBox.Show("Novi račun se može dodati samo ako ste prethodno izabrali klijenta na stranici Klijenti!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OcistiFormu();

            txtKlijent.Text = prosledjenoImeKlijenta; 
            txtKlijent.Enabled = false;

            txtBrojRacuna.Focus();
        }


        private void btnOdustani_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbTipFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!prosledjeniKlijentId.HasValue)
            {
                MessageBox.Show(
                    "Novi račun možete dodati samo ako ste prethodno izabrali klijenta na stranici Klijenti!",
                    "Obaveštenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!ValidacijaRacuna())
                return;

            RacunBasic rb = ProcitajPodatkeSaForme();

            bool uspesno = await DTOManager.AddRacun(rb, prosledjeniKlijentId.Value);

            if (uspesno)
            {
                MessageBox.Show("Račun je uspešno kreiran!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopulateInfos();
                OcistiFormu();
            }
        }

        private void cmbTipRacuna_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipRacuna_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipRacuna.SelectedItem == null) return;

            string izabraniTip = cmbTipRacuna.SelectedItem.ToString().ToLower().Trim();

            if (izabraniTip.Contains("teku"))
            {
                tabTipRacuna.SelectedIndex = 0;
            }
            else if (izabraniTip.Contains("sted") || izabraniTip.Contains("šted"))
            {
                tabTipRacuna.SelectedIndex = 1;
            }
            else if (izabraniTip.Contains("deviz"))
            {
                tabTipRacuna.SelectedIndex = 2;
            }
            else if (izabraniTip.Contains("zir") || izabraniTip.Contains("žir"))
            {
                tabTipRacuna.SelectedIndex = 3;
            }
        }
        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selektovaniRacun))
            {
                MessageBox.Show(
                    "Prvo izaberite racun iz tabele.",
                    "Racun klijenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }
            if (!ValidacijaRacuna())
                return;

            RacunBasic rb = ProcitajPodatkeSaForme();

            bool uspesno = await DTOManager.UpdateRacunBasic(rb);

            if (uspesno)
            {
                MessageBox.Show(
                    "Podaci o računu su uspešno izmenjeni.",
                    "Uspešna izmena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PopulateInfos();

                RacunBasic osvezenaForma = await DTOManager.GetRacunBasic(selektovaniRacun);
                PopulateData(osvezenaForma);
            }

        }

        private async void dgvRacuni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object vrednostId = dgvRacuni.Rows[e.RowIndex].Cells[0].Value;
            if (vrednostId == null)
                return;

            selektovaniRacun = vrednostId.ToString();

            cmbTipRacuna.Enabled = false;

            RacunBasic kb = await DTOManager.GetRacunBasic(selektovaniRacun);

            PopulateData(kb);
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selektovaniRacun))
            {
                MessageBox.Show("Prvo izaberite račun iz tabele.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete račun sa brojem {selektovaniRacun}?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                bool uspesno = await DTOManager.DeleteRacun(selektovaniRacun);

                if (uspesno)
                {
                    MessageBox.Show("Račun je uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateInfos();
                    OcistiFormu();
                }
            }
        }
    }
}
