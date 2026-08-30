using Banka.DTOs;
using Banka.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Banka.Forme
{
    public partial class UcTransakcije : UserControl
    {
        public int? selektovanaTransakcija = null;
        public string seleketovaniBrojRacunaPosiljaoca = null;
        List<TransakcijaPregled> sveTransakcije = DTOManager.GetTransakcijeInfos();
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
            sveTransakcije = DTOManager.GetTransakcijeInfos();
            dgvTransakcije.Rows.Clear();

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
            seleketovaniBrojRacunaPosiljaoca = null;
            dgvTransakcije.Refresh();
        }

        private void UcTransakcije_Load_1(object sender, EventArgs e)
        {
            PopulateInfos();
            PopulateRacuniCombo();
            OcistiFormu();
        }

        private void PopulateData(TransakcijaBasic tb)
        {
            if (tb == null)
                return;

            txtIznos.Text = tb.Iznos.ToString() ?? "";
            TimeSpan trenutnoVreme = DateTime.Now.TimeOfDay;
            string vremeString = trenutnoVreme.ToString(@"hh\:mm");
            txtVreme.Text = tb.Vreme ?? vremeString;
            cmbPoticeSa.SelectedItem = tb.BrojRacunaPosiljalac ?? "";
            cmbRacun.SelectedItem = tb.BrojRacunaPrimalac ?? "";
            txtReferenca.Text = tb.Referenca ?? "";
            txtOpis.Text = tb.Opis ?? "";
            txtKomentar.Text = tb.Komentar ?? "";

            if (tb.Datum.HasValue)
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

            object vrednostBrojRacuna = dgvTransakcije.Rows[e.RowIndex].Cells[2].Value;
            if (vrednostBrojRacuna == null)
                return;

            if (int.TryParse(vrednostId.ToString(), out int kodTransakcije))
            {
                selektovanaTransakcija = kodTransakcije;
                seleketovaniBrojRacunaPosiljaoca = vrednostBrojRacuna.ToString();

                TransakcijaBasic tb = await DTOManager.GetTransakcijaBasic(kodTransakcije, seleketovaniBrojRacunaPosiljaoca);

                PopulateData(tb);
            }
        }

        private void PopulateRacuniCombo()
        {
            cmbRacun.Items.Clear();
            cmbRacunFilter.Items.Clear();
            cmbPoticeSa.Items.Clear();

            List<RacunPregled> racuni = DTOManager.GetRacunInfo();

            cmbRacunFilter.Items.Add("Svi");
            cmbRacunFilter.SelectedIndex = 0;
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

            if (string.IsNullOrEmpty(cmbRacun.Text) && cmbTip.Text != "Isplata" && cmbTip.Text != "Konverzija")
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
                MessageBox.Show("Unesite ime i prezime primaoca.");
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
        private TransakcijaBasic ProcitajPodatkeSaForme()
        {
            TransakcijaBasic tb = new TransakcijaBasic();

            if (selektovanaTransakcija.HasValue)
                tb.KodTransakcije = selektovanaTransakcija.Value;

            if (seleketovaniBrojRacunaPosiljaoca != null)
                tb.BrojRacunaPosiljalac = seleketovaniBrojRacunaPosiljaoca;


            tb.TipTransakcije = cmbTip.SelectedItem.ToString();
            if (tb.TipTransakcije != "Konverzija" && tb.TipTransakcije != "Isplata")
            {
                tb.PodacioOPrimaocu = txtPrimalac.Text;
                tb.BrojRacunaPrimalac = cmbRacun.SelectedItem.ToString();
            }

            tb.Iznos = double.Parse(txtIznos.Text);
            tb.Valuta = cmbValuta.SelectedItem.ToString();
            tb.Datum = dtpDatum.Value;
            tb.Vreme = txtVreme.Text;
            tb.PodacioOPrimaocu = txtPrimalac.Text;
            tb.Status = cmbStatus.SelectedItem.ToString();
            tb.Referenca = txtReferenca.Text;
            tb.BrojRacunaPosiljalac = cmbPoticeSa.SelectedItem.ToString();
            tb.Opis = txtOpis.Text;
            tb.Komentar = txtKomentar.Text;

            return tb;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaTransakcije())
                return;

            if (selektovanaTransakcija != null || seleketovaniBrojRacunaPosiljaoca != null)
            {
                MessageBox.Show("Sačuvaj služi za dodavanje nove transakcije");
                return;
            }

            TransakcijaBasic tb = ProcitajPodatkeSaForme();

            bool success = await DTOManager.AddTransakcija(tb);
            if (success)
            {
                MessageBox.Show(
                    "Transakcija je uspešno dodata.",
                    "Uspesno dodavanje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PopulateInfos();
                OcistiFormu();
            }
        }

        private void OcistiFormu()
        {
            selektovanaTransakcija = null;
            seleketovaniBrojRacunaPosiljaoca = null;
            dgvTransakcije.ClearSelection();
            cmbRacun.SelectedIndex = -1;
            cmbTip.SelectedIndex = -1;
            txtIznos.Clear();
            cmbValuta.SelectedIndex = -1;
            dtpDatum.Value = DateTime.Today;
            TimeSpan trenutnoVreme = DateTime.Now.TimeOfDay;
            string vremeString = trenutnoVreme.ToString(@"hh\:mm");
            txtVreme.Text = vremeString;
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
            if (cmbTip.Text == "Isplata")
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
        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (!selektovanaTransakcija.HasValue || seleketovaniBrojRacunaPosiljaoca == null)
            {
                MessageBox.Show(
                    "Prvo izaberite transakciju iz tabele.",
                    "Brisanje transakcije",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete izabranu transakciju?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (rezultat != DialogResult.Yes)
                return;

            bool success = await DTOManager.DeleteTransakcija(selektovanaTransakcija.Value, seleketovaniBrojRacunaPosiljaoca);

            if (success)
            {
                MessageBox.Show(
                    "Transakcija je uspešno obrisana.",
                    "Uspeh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PopulateInfos();
                OcistiFormu();
            }
        }

        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!selektovanaTransakcija.HasValue || seleketovaniBrojRacunaPosiljaoca == null)
            {
                MessageBox.Show(
                    "Prvo izaberite transakciju iz tabele.",
                    "Izmena transakcije",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            if (!ValidacijaTransakcije())
                return;

            TransakcijaBasic tb = ProcitajPodatkeSaForme();

            if (tb.BrojRacunaPosiljalac != seleketovaniBrojRacunaPosiljaoca)
            {
                MessageBox.Show("Ne mozete menjati racun posiljaoca!");
                return;
            }

            bool success = await DTOManager.UpdateTransakcijaBasic(tb);

            if (success)
            {
                MessageBox.Show(
                    "Podaci o transakciji su uspešno izmenjeni.",
                    "Uspešna promena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                int idTransakcije = selektovanaTransakcija.Value;
                string brojRacuna = seleketovaniBrojRacunaPosiljaoca;

                PopulateInfos();

                TransakcijaBasic osvezeni = await DTOManager.GetTransakcijaBasic(idTransakcije, brojRacuna);

                PopulateData(osvezeni);
            }
        }

        private void PrimeniFiltere()
        {
            if (sveTransakcije == null)
                return;

            IEnumerable<TransakcijaPregled> rezultat = sveTransakcije;

            // pretraga - SAMO RACUN POSILJAOCA
            string pretragaRacun = cmbRacunFilter.Text?.Trim();

            if (!string.IsNullOrWhiteSpace(pretragaRacun) && pretragaRacun != "Svi")
            {
                rezultat = rezultat.Where(t =>
                    string.Equals(t.BrojRacunaPosiljalac, pretragaRacun, StringComparison.OrdinalIgnoreCase)
                );
            }

            // tip transakcije
            string selektovaniTip = cmbTipFilter.SelectedItem?.ToString() ?? cmbTipFilter.Text;

            if (!string.IsNullOrWhiteSpace(selektovaniTip) && selektovaniTip != "Svi")
            {
                rezultat = rezultat.Where(t =>
                    string.Equals(t.TipTransakcije, selektovaniTip, StringComparison.OrdinalIgnoreCase));
            }

            // status
            string selektovaniStatus = cmbStatusFilter.SelectedItem?.ToString() ?? cmbStatusFilter.Text;

            if (!string.IsNullOrWhiteSpace(selektovaniStatus) && selektovaniStatus != "Svi")
            {
                rezultat = rezultat.Where(t =>
                    string.Equals(t.Status, selektovaniStatus, StringComparison.OrdinalIgnoreCase));
            }

            // prikaz
            dgvTransakcije.Rows.Clear();

            foreach (TransakcijaPregled transakcija in rezultat)
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
            seleketovaniBrojRacunaPosiljaoca = null;
            dgvTransakcije.Refresh();
        }

        private void cmbRacunFilter_SelectedIndexChanged(object sender, EventArgs e)
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
