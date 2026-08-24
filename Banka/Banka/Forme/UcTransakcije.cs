using Banka.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Banka.Forme
{
    public partial class UcTransakcije : UserControl
    {
        public int? selektovanaTransakcija = null;
        public UcTransakcije()
        {
            InitializeComponent();
            cmbTipFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            cmbTip.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbValuta.SelectedIndex = 0;
        }

        private void PopulateInfos()
        {
            dgvTransakcije.Rows.Clear();
            List<TransakcijaPregled> sveTransakcije = DTOManager.GetTransakcijeInfos();

            foreach (TransakcijaPregled transakcija in sveTransakcije)
            {
                dgvTransakcije.Rows.Add(
                    transakcija.KodTransakcije,
                    transakcija.TipTransakcije ?? "",
                    transakcija.BrojRacunaPosiljalac ?? "",
                    transakcija.BrojRacunaPrimalac ?? "",
                    transakcija.Iznos.ToString() ?? "",
                    transakcija.Valuta ?? "",
                    transakcija.Status ?? "",
                    transakcija.Datum.ToString() ?? "",
                    transakcija.Vreme.ToString() ?? ""
                );
            }

            dgvTransakcije.Refresh();
        }

        private void UcTransakcije_Load_1(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateData(TransakcijaBasic tb)
        {
            if (tb == null)
                return;

            txtKod.Text = tb.KodTransakcije.ToString() ?? "";
            txtIznos.Text = tb.Iznos.ToString() ?? "";
            txtVreme.Text = tb.Vreme ?? "";
            txtPrimalac.Text = tb.BrojRacunaPrimalac ?? "";
            txtReferenca.Text = tb.Referenca ?? "";
            txtOpis.Text = tb.Opis ?? "";
            txtKomentar.Text = tb.Komentar ?? "";

            if(tb.Datum.HasValue) 
                dtpDatum.Value = tb.Datum.Value;

            if (tb.Valuta != null && cmbValuta.Items.Contains(tb.Valuta))
                cmbValuta.SelectedItem = tb.Valuta;

            if (tb.TipTransakcije != null && cmbTip.Items.Contains(tb.TipTransakcije))
                cmbTip.SelectedItem = tb.TipTransakcije;

            if (tb.Status != null && cmbStatus.Items.Contains(tb.Status))
                cmbStatus.SelectedItem = tb.Status;
        }

        private async void dgvTransakcije_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object vrednostId = dgvTransakcije.Rows[e.RowIndex].Cells[0].Value;
            if (vrednostId == null)
                return;

            if (int.TryParse(vrednostId.ToString(), out int kodTransakcije))
            {
                selektovanaTransakcija = kodTransakcije;

                TransakcijaBasic tb = await DTOManager.GetTransakcijaBasic(kodTransakcije);

                PopulateData(tb);
            }
        }

        private bool ValidacijaTransakcije()
        {
            if (string.IsNullOrWhiteSpace(txtKod.Text))
            {
                MessageBox.Show("Unesite Kod Transakcije.");
                return false;
            }

            if (cmbTip.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Tip Transakcije.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIznos.Text))
            {
                MessageBox.Show("Unesite Iznos.");
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Status.");
                return false;
            }
            //TREBA DA SE DOVRSI
            if (cmbValuta.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Valutu.");
                return false;
            }

            return true;
        }
    }
}
