using Banka.DTOs;
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
        public UcRacuni()
        {
            InitializeComponent();

            cmbStatusFilter.SelectedIndex = 0;
            cmbStatusRacuna.SelectedIndex = 0;
            cmbTipFilter.SelectedIndex = 0;
            cmbTipRacuna.SelectedIndex = 0;
            //cmbValuta.SelectedIndex = 0;
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
        /*private void PopulateInfos()
        {
            dgvRacuni.Rows.Clear();

            List<RacunPregled> racuni = DTOManager.GetRacunInfo();

            foreach (RacunPregled rp in racuni)
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
        }*/
        private void PopulateInfos()
        {
            // Učitavamo sve podatak u listu u memoriji
            sviRacuni = DTOManager.GetRacunInfo();

            // Primenjujemo filtere na tabelu
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
                // 1. Pretraga po broju računa ili klijentu
                (string.IsNullOrEmpty(pretragaTekst) ||
                 (r.BrojRacuna != null && r.BrojRacuna.ToLower().Contains(pretragaTekst)) ||
                 (r.ImeNaziv != null && r.ImeNaziv.ToLower().Contains(pretragaTekst))) &&

                // 2. Filter po tipu
                (selektovaniTip.Contains("svi") || (r.TipRacuna != null && r.TipRacuna.ToLower().Contains(selektovaniTip))) &&

                // 3. Filter po statusu
                (selektovaniStatus.Contains("svi") || (r.StatusRacuna != null && r.StatusRacuna.ToLower().Contains(selektovaniStatus)))
            ).ToList();

            // Osvežavanje DataGridView-a
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
            if(rb == null) return;

            txtBrojRacuna.Text = rb.BrojRacuna ?? "";
            //treba da se zameni combobox u textbox za Klijenta
            txtTrenutnoStanje.Text = rb.TrenutnoStanje.ToString();
            txtKamatnaStopa.Text = rb.KamatnaStopa.ToString();
            txtKomentar.Text = rb.Komentar.ToString();
            txtDozvoljeniMinus.Text = rb.DozvoljeniMinus.ToString();
            if(cmbStatusRacuna.Items.Contains(rb.StatusRacuna))
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

            if(rb.TipRacuna == "tekuci")
            {
                cmbTipRacuna.SelectedItem = "Tekuci";
                tabTipRacuna.SelectedIndex = 0;
                if (rb.MogucnostPlatnihKartica == "da")
                    chkPlatneKartice.Checked = true;
                else chkPlatneKartice.Checked = false;
                txtMesecniLimit.Text = rb.MesecniLimitTransakcija.ToString();
                txtPaketiUsluga.Text = "";//treba da se poveze
            }
            else if(rb.TipRacuna == "stedni")
            {
                cmbTipRacuna.SelectedItem = "Stedni";
                tabTipRacuna.SelectedIndex = 1;
                txtMinimalniIznos.Text = rb.MinimalniIznosZaOtvaranje.ToString();
                txtUsloviPodizanja.Text = rb.UsloviPodizanjaSredstava ?? "";
                txtFrekvencija.Text = rb.Frekvencija ?? "";
                txtBonusi.Text = rb.BonusiZaDugorocnuStednju.ToString();
            }
            else if(rb.TipRacuna == "devizni")
            {
                cmbTipRacuna.SelectedItem = "Devizni";
                tabTipRacuna.SelectedIndex = 2;
                txtDozvoljeneValute.Text = "";//treba da se doda
                txtNamenaDevizni.Text = rb.NamenaDevizni ?? "";
                txtKursnaRazlika.Text = rb.KursnaRazlikaKonverzije.ToString();
                txtOgranicenja.Text = rb.OgranicenjaDeviznihPropisa ?? "";
            }
            else if(rb.TipRacuna == "ziro")
            {
                cmbTipRacuna.SelectedItem = "Ziro";
                tabTipRacuna.SelectedIndex = 3;
                txtNamenaZiro.Text = rb.NamenaZiro ?? "";
                txtLimitMasovnih.Text = rb.LimitMasovnihPlacanja.ToString();
                txtIntegracija.Text = rb.Integracija.ToString();
                if (rb.EBankarstvoZaFirme == "da")
                    chkEBankarstvo.Checked = true;
                else chkEBankarstvo.Checked = false;

            }
        }


        private RacunBasic ProcitajPodatkeSaForme()
        {
            RacunBasic rb = new RacunBasic();

            rb.BrojRacuna = txtBrojRacuna.Text.Trim();
            cmbKlijent.SelectedItem?.ToString();
            rb.TipRacuna = cmbTipRacuna.SelectedItem?.ToString().ToLower().Trim();
            rb.Valuta = cmbValuta.SelectedItem?.ToString();
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

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();
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
    }
}
