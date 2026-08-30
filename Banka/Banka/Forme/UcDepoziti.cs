using System;
using System.Linq;
using Banka.DTOs;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Banka.Forme
{
    public partial class UcDepoziti : UserControl
    {
        private List<DepozitPregled> sviDepoziti = new List<DepozitPregled>();
        private List<KlijentPregled> sviKlijenti = new List<KlijentPregled>();
        private List<RacunPregled> sviRacuni = new List<RacunPregled>();
        private int? selektovanDepozitId = null;

        public UcDepoziti()
        {
            InitializeComponent();

            PopulateInfos();
            PopuniKlijenteIRacune();
            PopuniFiltere();

            if (cmbValuta.Items.Count > 0)
                cmbValuta.SelectedIndex = 0;

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
        }

        private void PopulateInfos()
        {
            sviDepoziti = DTOManager.GetDepozitiInfos().OrderBy(d => d.Id).ToList();
            PopuniTabelu(sviDepoziti);
        }

        private void PopuniTabelu(IEnumerable<DepozitPregled> depoziti)
        {
            dgvDepoziti.Rows.Clear();

            foreach (DepozitPregled d in depoziti)
                dgvDepoziti.Rows.Add(d.Id, d.KlijentNaziv, d.Iznos.ToString("0.00"), d.DatumPocetka.ToString("dd.MM.yyyy."), d.Valuta, d.Status);

            dgvDepoziti.ClearSelection();
            dgvDepoziti.Refresh();
        }

        private void PopuniFiltere()
        {
            cmbKlijentFilter.Items.Clear();
            cmbKlijentFilter.Items.Add("Svi");

            foreach (KlijentPregled k in sviKlijenti)
                cmbKlijentFilter.Items.Add(k.ImeNaziv);

            cmbKlijentFilter.SelectedIndex = 0;

            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Svi");

            foreach (var item in cmbStatus.Items)
                cmbStatusFilter.Items.Add(item);

            cmbStatusFilter.SelectedIndex = 0;
        }

        private void PrimeniFiltere()
        {
            IEnumerable<DepozitPregled> rezultat = sviDepoziti;

            string klijent = cmbKlijentFilter.Text.Trim();
            if (!string.IsNullOrEmpty(klijent) && klijent != "Svi")
                rezultat = rezultat.Where(d => d.KlijentNaziv != null && d.KlijentNaziv.IndexOf(klijent, StringComparison.OrdinalIgnoreCase) >= 0);

            string status = cmbStatusFilter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status) && status != "Svi")
                rezultat = rezultat.Where(d => d.Status == status);

            PopuniTabelu(rezultat);
        }

        private void PopuniKlijenteIRacune()
        {
            sviKlijenti = DTOManager.GetKlijentInfos().OrderBy(k => k.KlijentId).ToList();
            sviRacuni = DTOManager.GetRacunInfo().OrderBy(r => r.BrojRacuna).ToList();

            cmbKlijent.DisplayMember = "ImeNaziv";
            cmbKlijent.ValueMember = "KlijentId";
            cmbKlijent.DataSource = sviKlijenti;

            PopuniRacuneZaKlijenta();
        }

        private void PopuniRacuneZaKlijenta()
        {
            if (cmbKlijent.SelectedValue == null)
            {
                cmbRacun.DataSource = null;
                return;
            }

            int klijentId = Convert.ToInt32(cmbKlijent.SelectedValue);
            List<RacunPregled> racuniKlijenta = sviRacuni.Where(r => r.KlijentId == klijentId).OrderBy(r => r.BrojRacuna).ToList();

            cmbRacun.DisplayMember = "BrojRacuna";
            cmbRacun.ValueMember = "BrojRacuna";
            cmbRacun.DataSource = racuniKlijenta;
        }

        private void OcistiFormu()
        {
            selektovanDepozitId = null;
            btnSacuvaj.Enabled = true;

            txtId.Clear();

            if (cmbKlijent.Items.Count > 0)
                cmbKlijent.SelectedIndex = 0;

            txtIznos.Clear();
            txtPeriodOrocenja.Clear();
            txtKamatnaStopa.Clear();
            txtOcekivanaKamata.Clear();
            txtKomentar.Clear();

            dtpDatumPocetka.Value = DateTime.Today;
            dtpDatumIsteka.Value = DateTime.Today.AddMonths(1);

            if (cmbValuta.Items.Count > 0)
                cmbValuta.SelectedIndex = 0;

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;

            dgvDepoziti.ClearSelection();
        }

        private void cmbKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopuniRacuneZaKlijenta();
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbKlijent.SelectedValue == null || cmbRacun.SelectedValue == null || cmbValuta.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Popunite sva obavezna polja.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            double iznos;

            if (!double.TryParse(txtIznos.Text.Trim(), out iznos) || iznos <= 0)
            {
                MessageBox.Show(
                    "Unesite ispravan iznos depozita.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtIznos.Focus();
                return;
            }

            int period;

            if (!int.TryParse(txtPeriodOrocenja.Text.Trim(), out period) || period <= 0)
            {
                MessageBox.Show(
                    "Unesite ispravan period oročenja.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtPeriodOrocenja.Focus();
                return;
            }

            double kamatnaStopa;

            if (!double.TryParse(txtKamatnaStopa.Text.Trim(), out kamatnaStopa) || kamatnaStopa < 0)
            {
                MessageBox.Show(
                    "Unesite ispravnu kamatnu stopu.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtKamatnaStopa.Focus();
                return;
            }

            double ocekivanaKamata;

            if (!double.TryParse(txtOcekivanaKamata.Text.Trim(), out ocekivanaKamata) || ocekivanaKamata < 0)
            {
                MessageBox.Show(
                    "Unesite ispravnu očekivanu kamatu.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtOcekivanaKamata.Focus();
                return;
            }

            if (dtpDatumIsteka.Value.Date <= dtpDatumPocetka.Value.Date)
            {
                MessageBox.Show(
                    "Datum isteka mora biti nakon datuma početka.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            DepozitBasic depozit = new DepozitBasic();

            depozit.KlijentId = Convert.ToInt32(cmbKlijent.SelectedValue);
            depozit.BrojRacuna = cmbRacun.SelectedValue.ToString();
            depozit.Iznos = iznos;
            depozit.Valuta = cmbValuta.SelectedItem.ToString();
            depozit.KamatnaStopa = kamatnaStopa;
            depozit.PeriodOrocenja = period;
            depozit.DatumPocetka = dtpDatumPocetka.Value.Date;
            depozit.DatumIsteka = dtpDatumIsteka.Value.Date;
            depozit.Status = cmbStatus.SelectedItem.ToString();
            depozit.OcekivanaKamata = ocekivanaKamata;
            depozit.Komentar = txtKomentar.Text.Trim();

            bool success = await DTOManager.AddDepozit(depozit);

            if (success)
            {
                MessageBox.Show(
                    "Depozit je uspešno dodat.", 
                    "Uspeh", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                OcistiFormu();
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();
            cmbKlijent.Focus();
        }

        private void dgvDepoziti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvDepoziti.Rows[e.RowIndex].Cells["colId"].Value);
            DepozitBasic depozit = DTOManager.GetDepozitBasic(id);

            if (depozit == null)
                return;

            selektovanDepozitId = depozit.Id;
            btnSacuvaj.Enabled = false;

            txtId.Text = depozit.Id.ToString();

            cmbKlijent.SelectedValue = depozit.KlijentId;
            cmbRacun.SelectedValue = depozit.BrojRacuna;

            txtIznos.Text = depozit.Iznos.ToString("0.00");
            txtPeriodOrocenja.Text = depozit.PeriodOrocenja?.ToString() ?? "";
            dtpDatumPocetka.Value = depozit.DatumPocetka;
            cmbValuta.SelectedItem = depozit.Valuta;
            txtOcekivanaKamata.Text = depozit.OcekivanaKamata?.ToString("0.00") ?? "";

            if (depozit.DatumIsteka.HasValue)
                dtpDatumIsteka.Value = depozit.DatumIsteka.Value;

            cmbStatus.SelectedItem = depozit.Status;
            txtKamatnaStopa.Text = depozit.KamatnaStopa?.ToString("0.00") ?? "";
            txtKomentar.Text = depozit.Komentar;
        }

        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!selektovanDepozitId.HasValue)
            {
                MessageBox.Show(
                    "Izaberite depozit koji želite da izmenite.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbKlijent.SelectedValue == null || cmbRacun.SelectedValue == null || cmbValuta.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Popunite sva obavezna polja.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            double iznos;

            if (!double.TryParse(txtIznos.Text.Trim(), out iznos) || iznos <= 0)
            {
                MessageBox.Show(
                    "Unesite ispravan iznos depozita.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtIznos.Focus();
                return;
            }

            int period;

            if (!int.TryParse(txtPeriodOrocenja.Text.Trim(), out period) || period <= 0)
            {
                MessageBox.Show(
                    "Unesite ispravan period oročenja.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtPeriodOrocenja.Focus();
                return;
            }

            double kamatnaStopa;

            if (!double.TryParse(txtKamatnaStopa.Text.Trim(), out kamatnaStopa) || kamatnaStopa < 0)
            {
                MessageBox.Show(
                    "Unesite ispravnu kamatnu stopu.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtKamatnaStopa.Focus();
                return;
            }

            double ocekivanaKamata;

            if (!double.TryParse(txtOcekivanaKamata.Text.Trim(), out ocekivanaKamata) || ocekivanaKamata < 0)
            {
                MessageBox.Show(
                    "Unesite ispravnu očekivanu kamatu.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtOcekivanaKamata.Focus();
                return;
            }

            if (dtpDatumIsteka.Value.Date <= dtpDatumPocetka.Value.Date)
            {
                MessageBox.Show(
                    "Datum isteka mora biti nakon datuma početka.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            DepozitBasic depozit = new DepozitBasic();

            depozit.Id = selektovanDepozitId.Value;
            depozit.KlijentId = Convert.ToInt32(cmbKlijent.SelectedValue);
            depozit.BrojRacuna = cmbRacun.SelectedValue.ToString();
            depozit.Iznos = iznos;
            depozit.Valuta = cmbValuta.SelectedItem.ToString();
            depozit.KamatnaStopa = kamatnaStopa;
            depozit.PeriodOrocenja = period;
            depozit.DatumPocetka = dtpDatumPocetka.Value.Date;
            depozit.DatumIsteka = dtpDatumIsteka.Value.Date;
            depozit.Status = cmbStatus.SelectedItem.ToString();
            depozit.OcekivanaKamata = ocekivanaKamata;
            depozit.Komentar = txtKomentar.Text.Trim();

            bool success = await DTOManager.UpdateDepozit(depozit);

            if (success)
            {
                MessageBox.Show(
                    "Depozit je uspešno izmenjen.", 
                    "Uspeh", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                OcistiFormu();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (!selektovanDepozitId.HasValue)
            {
                MessageBox.Show(
                    "Izaberite depozit koji želite da obrišete.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete izabrani depozit?", 
                "Potvrda brisanja", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (rezultat != DialogResult.Yes)
                return;

            bool success = await DTOManager.DeleteDepozit(selektovanDepozitId.Value);

            if (success)
            {
                MessageBox.Show(
                    "Depozit je uspešno obrisan.", 
                    "Uspeh", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                OcistiFormu();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void cmbKlijentFilter_TextUpdate(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbKlijentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        
    }
}
