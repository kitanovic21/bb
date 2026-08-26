using Banka.DTOs;
using Banka.Entiteti;
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

            dgvTransakcije.ClearSelection();
            selektovanaTransakcija = null;
            dgvTransakcije.Refresh();
        }

        private void UcTransakcije_Load_1(object sender, EventArgs e)
        {
            PopulateInfos();
            PopulateRacuniCombo();
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

        private void PopulateRacuniCombo()
        {
            cmbRacun.Items.Clear();
            cmbRacunFilter.Items.Clear();
            cmbPoticeSa.Items.Clear();

            List<RacunPregled> racuni = DTOManager.GetRacunInfo();


            foreach (RacunPregled racun in racuni)
            {
                string brojRacuna = racun.BrojRacuna.ToString();
                cmbRacun.Items.Add(brojRacuna);
                cmbRacunFilter.Items.Add(brojRacuna);
                cmbPoticeSa.Items.Add(brojRacuna);
            }
        }

        private bool ValidacijaTransakcije()
        {
            if (string.IsNullOrWhiteSpace(txtKod.Text))
            {
                MessageBox.Show("Unesite Kod Transakcije.");
                return false;
            }

            if (string.IsNullOrEmpty(cmbRacun.Text) && cmbTip.Text!= "Isplata" && cmbTip.Text!="Konverzija")
            {
                MessageBox.Show("Unesite Racun primaoca.");
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

            if (cmbValuta.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Valutu.");
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Status.");
                return false;
            }

            if (string.IsNullOrEmpty(txtVreme.Text))
            {
                MessageBox.Show("Unesite vreme.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPrimalac.Text) && cmbTip.Text != "Isplata" && cmbTip.Text != "Konverzija")
            {
                MessageBox.Show("Unesite ime i prezime primaoca." );
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status transakcije");
                return false;
            }

            if (string.IsNullOrEmpty(txtReferenca.Text))
            {
                MessageBox.Show("Unesite referencu.");
                return false;
            }

            if (string.IsNullOrEmpty(cmbPoticeSa.Text))
            {
                MessageBox.Show("Unesite Racun posiljaoca.");
                return false;
            }


            return true;
        }

        private void dgvTransakcije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaTransakcije())
                return;

            if (selektovanaTransakcija != null)
            {
                MessageBox.Show("Sačuvaj služi za dodavanje nove transakcije");
                return;
            }


        }

        private void OcistiFormu()
        {
            selektovanaTransakcija = null;
            dgvTransakcije.ClearSelection();
            txtKod.Clear();
            cmbRacun.SelectedIndex = -1;
            cmbTip.SelectedIndex = -1;
            txtIznos.Clear();
            cmbValuta.SelectedIndex = -1;
            dtpDatum.Value = DateTime.Today;
            txtVreme.Clear();
            txtPrimalac.Clear();
            cmbStatus.SelectedIndex = -1;
            txtReferenca.Clear();
            cmbPoticeSa.SelectedIndex = -1;
            txtOpis.Clear();
            txtKomentar.Clear();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTip.Text == "Isplata" || cmbTip.Text == "Konverzija")
            {
                cmbRacun.Enabled = false;
                cmbRacun.SelectedIndex = -1;
                cmbRacun.Text = string.Empty;
            }
            else
            {
                cmbRacun.Enabled = true;
            }
        }
    }
}
