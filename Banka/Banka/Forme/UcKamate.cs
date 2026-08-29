using Banka.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Banka.Forme
{
    public partial class UcKamate : UserControl
    {
        private List<KamataPregled> sveKamate = new List<KamataPregled>();
        private List<PredmetObracunaOpcija> sviKonkretniPredmeti = new List<PredmetObracunaOpcija>();
        private int? selektovanaKamataId = null;

        public UcKamate()
        {
            InitializeComponent();

            PopulateInfos();
            PopuniFiltere();

            cmbPredmet.SelectedIndex = 0;
            cmbTipKamate.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void OcistiFormu()
        {
            selektovanaKamataId = null;
            btnSacuvaj.Enabled = true;

            txtId.Clear();

            if (cmbPredmet.Items.Count > 0)
                cmbPredmet.SelectedIndex = 0;

            cmbTipKamate.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            txtIznosKamate.Clear();
            txtPeriodObracuna.Clear();
            dtpDatumObracuna.Value = DateTime.Today;

            dgvKamate.ClearSelection();
        }

        private void PopulateInfos()
        {
            sveKamate = DTOManager.GetKamateInfos().OrderBy(k => k.Id).ToList();
            PopuniTabelu(sveKamate);
        }

        private void PopuniTabelu(IEnumerable<KamataPregled> kamate)
        {
            dgvKamate.Rows.Clear();

            foreach (KamataPregled k in kamate)
            {
                dgvKamate.Rows.Add(
                    k.Id,
                    k.PredmetTip,
                    k.KonkretanPredmet,
                    k.TipKamate,
                    k.IznosKamate.ToString("0.00"),
                    k.PeriodObracuna,
                    k.DatumObracuna.ToString("dd.MM.yyyy."),
                    k.Status
                );
            }

            dgvKamate.ClearSelection();
            dgvKamate.Refresh();
        }

        private void PopuniFiltere()
        {
            cmbPredmetFilter.Items.Clear();
            cmbPredmetFilter.Items.Add("Svi");
            cmbPredmetFilter.Items.Add("Račun");
            cmbPredmetFilter.Items.Add("Kredit");
            cmbPredmetFilter.Items.Add("Depozit");
            cmbPredmetFilter.SelectedIndex = 0;

            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Svi");

            foreach (var item in cmbStatus.Items)
                cmbStatusFilter.Items.Add(item);

            cmbStatusFilter.SelectedIndex = 0;
        }

        private void PrimeniFiltere()
        {
            IEnumerable<KamataPregled> rezultat = sveKamate;

            string predmet = cmbPredmetFilter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(predmet) && predmet != "Svi")
                rezultat = rezultat.Where(k => k.PredmetTip == predmet);

            string status = cmbStatusFilter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status) && status != "Svi")
                rezultat = rezultat.Where(k => k.Status == status);

            PopuniTabelu(rezultat);
        }

        private void PopuniKonkretnePredmete()
        {
            if (cmbPredmet.SelectedItem == null)
                return;

            string tip = cmbPredmet.SelectedItem.ToString();
            sviKonkretniPredmeti = DTOManager.GetPredmetiObracuna(tip);

            cmbKonkretanPredmet.DisplayMember = "Prikaz";
            cmbKonkretanPredmet.ValueMember = "PredmetObracunaId";
            cmbKonkretanPredmet.DataSource = sviKonkretniPredmeti;
        }

        private void cmbPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopuniKonkretnePredmete();
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbKonkretanPredmet.SelectedValue == null || cmbTipKamate.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Popunite sva obavezna polja.",
                    "Upozorenje", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            double iznos;

            if (!double.TryParse(txtIznosKamate.Text.Trim(), out iznos) || iznos < 0)
            {
                MessageBox.Show(
                    "Unesite ispravan iznos kamate.",
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtIznosKamate.Focus();
                return;
            }

            KamataBasic kamata = new KamataBasic();

            kamata.PredmetObracunaId = Convert.ToInt32(cmbKonkretanPredmet.SelectedValue);
            kamata.TipKamate = cmbTipKamate.SelectedItem.ToString();
            kamata.IznosKamate = iznos;
            kamata.PeriodObracuna = txtPeriodObracuna.Text.Trim();
            kamata.DatumObracuna = dtpDatumObracuna.Value.Date;
            kamata.Status = cmbStatus.SelectedItem.ToString();

            bool success = await DTOManager.AddKamata(kamata);

            if (success)
            {
                MessageBox.Show(
                    "Kamata je uspešno dodata.",
                    "Uspeh", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                PrimeniFiltere();
                OcistiFormu();
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();
            cmbPredmet.Focus();
        }

        private void dgvKamate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvKamate.Rows[e.RowIndex].Cells["colId"].Value);
            KamataPregled kamata = sveKamate.FirstOrDefault(k => k.Id == id);

            if (kamata == null)
                return;

            selektovanaKamataId = kamata.Id;
            btnSacuvaj.Enabled = false;

            txtId.Text = kamata.Id.ToString();

            cmbPredmet.SelectedItem = kamata.PredmetTip;
            cmbKonkretanPredmet.SelectedValue = kamata.PredmetObracunaId;

            cmbTipKamate.SelectedItem = kamata.TipKamate;
            txtIznosKamate.Text = kamata.IznosKamate.ToString("0.00");
            txtPeriodObracuna.Text = kamata.PeriodObracuna;
            dtpDatumObracuna.Value = kamata.DatumObracuna;
            cmbStatus.SelectedItem = kamata.Status;
        }

        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!selektovanaKamataId.HasValue)
            {
                MessageBox.Show(
                    "Izaberite kamatu koju želite da izmenite.",
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbKonkretanPredmet.SelectedValue == null || cmbTipKamate.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Popunite sva obavezna polja.",
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            double iznos;

            if (!double.TryParse(txtIznosKamate.Text.Trim(), out iznos) || iznos < 0)
            {
                MessageBox.Show(
                    "Unesite ispravan iznos kamate.",
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                txtIznosKamate.Focus();
                return;
            }

            KamataBasic kamata = new KamataBasic();

            kamata.Id = selektovanaKamataId.Value;
            kamata.PredmetObracunaId = Convert.ToInt32(cmbKonkretanPredmet.SelectedValue);
            kamata.TipKamate = cmbTipKamate.SelectedItem.ToString();
            kamata.IznosKamate = iznos;
            kamata.PeriodObracuna = txtPeriodObracuna.Text.Trim();
            kamata.DatumObracuna = dtpDatumObracuna.Value.Date;
            kamata.Status = cmbStatus.SelectedItem.ToString();

            bool success = await DTOManager.UpdateKamata(kamata);

            if (success)
            {
                MessageBox.Show(
                    "Kamata je uspešno izmenjena.",
                    "Uspeh", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                PrimeniFiltere();
                OcistiFormu();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (!selektovanaKamataId.HasValue)
            {
                MessageBox.Show(
                    "Izaberite kamatu koju želite da obrišete.", 
                    "Upozorenje", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete izabranu kamatu?", 
                "Potvrda brisanja", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (rezultat != DialogResult.Yes)
                return;

            bool success = await DTOManager.DeleteKamata(selektovanaKamataId.Value);

            if (success)
            {
                MessageBox.Show(
                    "Kamata je uspešno obrisana.", 
                    "Uspeh",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                PrimeniFiltere();
                OcistiFormu();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void cmbPredmetFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbKonkretanPredmet_TextUpdate(object sender, EventArgs e)
        {
            string tekst = cmbKonkretanPredmet.Text.Trim();

            List<PredmetObracunaOpcija> rezultat = sviKonkretniPredmeti
                .Where(p => p.Prikaz != null && p.Prikaz.IndexOf(tekst, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            cmbKonkretanPredmet.DataSource = rezultat;
            cmbKonkretanPredmet.DisplayMember = "Prikaz";
            cmbKonkretanPredmet.ValueMember = "PredmetObracunaId";

            cmbKonkretanPredmet.Text = tekst;
            cmbKonkretanPredmet.SelectionStart = tekst.Length;
            cmbKonkretanPredmet.DroppedDown = true;
        }
    }
}
