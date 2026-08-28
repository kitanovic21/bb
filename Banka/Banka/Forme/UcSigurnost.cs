using Banka.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Banka.Forme
{
    public partial class UcSigurnost : UserControl
    {
        private List<SigurnosnaKontrolaPregled> sveKontrole = new List<SigurnosnaKontrolaPregled>();
        private List<KlijentPregled> sviKlijenti = new List<KlijentPregled>();
        private List<RacunPregled> sviRacuni = new List<RacunPregled>();
        private int? selektovanaKontrolaId = null;

        public UcSigurnost()
        {
            InitializeComponent();

            PopulateInfos();
            PopuniKlijenteIRacune();
            PopuniFiltere();

            cmbTipDogadjaja.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void PopulateInfos()
        {
            sveKontrole = DTOManager.GetSigurnosneKontroleInfos()
                                    .OrderBy(k => k.Id)
                                    .ToList();

            PopuniTabelu(sveKontrole);
        }

        private void PopuniTabelu(IEnumerable<SigurnosnaKontrolaPregled> kontrole)
        {
            dgvSigurnost.Rows.Clear();

            foreach (SigurnosnaKontrolaPregled sk in kontrole)
            {
                dgvSigurnost.Rows.Add(
                    sk.Id,
                    sk.KlijentNaziv ?? "",
                    sk.BrojRacuna ?? "",
                    sk.TipDogadjaja ?? "",
                    sk.Datum.ToString("dd.MM.yyyy."),
                    sk.Vreme ?? "",
                    sk.IpAdresa ?? "",
                    sk.Status ?? ""
                );
            }

            dgvSigurnost.ClearSelection();
            dgvSigurnost.Refresh();
        }

        private void PopuniKlijenteIRacune()
        {
            sviKlijenti = DTOManager.GetKlijentInfos()
                                    .OrderBy(k => k.KlijentId)
                                    .ToList();

            sviRacuni = DTOManager.GetRacunInfo()
                                  .OrderBy(r => r.BrojRacuna)
                                  .ToList();

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

            List<RacunPregled> racuniKlijenta = sviRacuni
                .Where(r => r.KlijentId == klijentId)
                .OrderBy(r => r.BrojRacuna)
                .ToList();

            cmbRacun.DataSource = racuniKlijenta;
            cmbRacun.DisplayMember = "BrojRacuna";
            cmbRacun.ValueMember = "BrojRacuna";
        }

        private void OcistiFormu()
        {
            selektovanaKontrolaId = null;
            btnSacuvaj.Enabled = true;

            txtId.Clear();

            if (cmbKlijent.Items.Count > 0)
                cmbKlijent.SelectedIndex = 0;

            cmbTipDogadjaja.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            dtpDatum.Value = DateTime.Today;

            txtVreme.Clear();
            txtIpAdresa.Clear();
            txtUredjaj.Clear();
            txtOpis.Clear();

            dgvSigurnost.ClearSelection();
        }

        private void PopuniFiltere()
        {
            var klijentiFilter = new List<KeyValuePair<int, string>>();
            klijentiFilter.Add(new KeyValuePair<int, string>(0, "Svi"));

            foreach (KlijentPregled k in sviKlijenti)
                klijentiFilter.Add(new KeyValuePair<int, string>(k.KlijentId, k.ImeNaziv));

            cmbKlijentFilter.DisplayMember = "Value";
            cmbKlijentFilter.ValueMember = "Key";
            cmbKlijentFilter.DataSource = klijentiFilter;

            cmbTipFilter.Items.Clear();
            cmbTipFilter.Items.Add("Svi");

            cmbTipFilter.Items.Clear();
            cmbTipFilter.Items.Add("Svi");

            foreach (var item in cmbTipDogadjaja.Items)
            {
                cmbTipFilter.Items.Add(item);
            }

            cmbTipFilter.SelectedIndex = 0;

            PopuniRacunFilter();
        }

        private void PopuniRacunFilter()
        {
            int klijentId = Convert.ToInt32(cmbKlijentFilter.SelectedValue);

            IEnumerable<RacunPregled> racuni = sviRacuni;

            if (klijentId != 0)
                racuni = racuni.Where(r => r.KlijentId == klijentId);

            var racuniFilter = new List<KeyValuePair<string, string>>();
            racuniFilter.Add(new KeyValuePair<string, string>("", "Svi"));

            foreach (RacunPregled r in racuni.OrderBy(r => r.BrojRacuna))
                racuniFilter.Add(new KeyValuePair<string, string>(r.BrojRacuna, r.BrojRacuna));

            cmbRacunFilter.DisplayMember = "Value";
            cmbRacunFilter.ValueMember = "Key";
            cmbRacunFilter.DataSource = racuniFilter;
        }

        private void PrimeniFiltere()
        {
            IEnumerable<SigurnosnaKontrolaPregled> rezultat = sveKontrole;

            int klijentId = Convert.ToInt32(cmbKlijentFilter.SelectedValue);

            if (klijentId != 0)
                rezultat = rezultat.Where(k => k.KlijentId == klijentId);

            string brojRacuna = cmbRacunFilter.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(brojRacuna))
                rezultat = rezultat.Where(k => k.BrojRacuna == brojRacuna);

            string tip = cmbTipFilter.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tip) && tip != "Svi")
                rezultat = rezultat.Where(k => k.TipDogadjaja == tip);

            PopuniTabelu(rezultat);
        }

        private void cmbKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopuniRacuneZaKlijenta();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();
            cmbKlijent.Focus();
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbKlijent.SelectedValue == null ||
                cmbRacun.SelectedValue == null ||
                cmbTipDogadjaja.SelectedItem == null ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Izaberite klijenta, račun, tip događaja i status.",
                    "Nedostaju podaci",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            SigurnosnaKontrolaBasic sk = new SigurnosnaKontrolaBasic();

            sk.KlijentId = Convert.ToInt32(cmbKlijent.SelectedValue);
            sk.BrojRacuna = cmbRacun.SelectedValue.ToString();

            sk.TipDogadjaja = cmbTipDogadjaja.SelectedItem.ToString();
            sk.Datum = dtpDatum.Value.Date;
            sk.Vreme = txtVreme.Text.Trim();

            sk.IpAdresa = txtIpAdresa.Text.Trim();
            sk.PodaciOUredjaju = txtUredjaj.Text.Trim();

            sk.Status = cmbStatus.SelectedItem.ToString();
            sk.Opis = txtOpis.Text.Trim();

            bool uspeh = await DTOManager.AddSigurnosnaKontrola(sk);

            if (uspeh)
            {
                MessageBox.Show(
                    "Sigurnosna kontrola je uspešno dodata.",
                    "Uspeh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PopulateInfos();
                OcistiFormu();
            }
        }

        private void dgvSigurnost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvSigurnost.Rows[e.RowIndex].Cells[0].Value);

            SigurnosnaKontrolaBasic sk = DTOManager.GetSigurnosnaKontrolaBasic(id);

            if (sk == null)
                return;

            selektovanaKontrolaId = sk.Id;
            btnSacuvaj.Enabled = false;
            txtId.Text = sk.Id.ToString();
            cmbKlijent.SelectedValue = sk.KlijentId;
            cmbRacun.SelectedValue = sk.BrojRacuna;
            cmbTipDogadjaja.SelectedItem = sk.TipDogadjaja;
            dtpDatum.Value = sk.Datum;
            txtVreme.Text = sk.Vreme ?? "";
            txtIpAdresa.Text = sk.IpAdresa ?? "";
            txtUredjaj.Text = sk.PodaciOUredjaju ?? "";
            cmbStatus.SelectedItem = sk.Status;
            txtOpis.Text = sk.Opis ?? "";
        }

        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!selektovanaKontrolaId.HasValue)
            {
                MessageBox.Show(
                    "Prvo izaberite sigurnosnu kontrolu iz tabele.",
                    "Izmena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cmbKlijent.SelectedValue == null ||
                cmbRacun.SelectedValue == null ||
                cmbTipDogadjaja.SelectedItem == null ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite klijenta, račun, tip događaja i status.");
                return;
            }

            SigurnosnaKontrolaBasic sk = new SigurnosnaKontrolaBasic();

            sk.Id = selektovanaKontrolaId.Value;
            sk.KlijentId = Convert.ToInt32(cmbKlijent.SelectedValue);
            sk.BrojRacuna = cmbRacun.SelectedValue.ToString();
            sk.TipDogadjaja = cmbTipDogadjaja.SelectedItem.ToString();
            sk.Datum = dtpDatum.Value.Date;
            sk.Vreme = txtVreme.Text.Trim();
            sk.IpAdresa = txtIpAdresa.Text.Trim();
            sk.PodaciOUredjaju = txtUredjaj.Text.Trim();
            sk.Status = cmbStatus.SelectedItem.ToString();
            sk.Opis = txtOpis.Text.Trim();

            bool success = await DTOManager.UpdateSigurnosnaKontrola(sk);

            if (success)
            {
                MessageBox.Show(
                    "Sigurnosna kontrola je uspešno izmenjena.", 
                    "Uspeh", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                PopulateInfos();
                OcistiFormu();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (!selektovanaKontrolaId.HasValue)
            {
                MessageBox.Show(
                    "Prvo izaberite sigurnosnu kontrolu iz tabele.",
                    "Brisanje",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete izabranu sigurnosnu kontrolu?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (rezultat != DialogResult.Yes)
                return;

            bool uspeh = await DTOManager.DeleteSigurnosnaKontrola(selektovanaKontrolaId.Value);

            if (uspeh)
            {
                MessageBox.Show(
                    "Sigurnosna kontrola je uspešno obrisana.", 
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

        private void cmbKlijentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKlijentFilter.SelectedValue == null)
                return;

            PopuniRacunFilter();
            PrimeniFiltere();
        }

        private void cmbRacunFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbTipFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }
    }
}
