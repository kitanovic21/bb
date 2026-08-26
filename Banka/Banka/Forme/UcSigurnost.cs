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

        public UcSigurnost()
        {
            InitializeComponent();

            PopulateInfos();
            PopuniKlijenteIRacune();

            cmbTipDogadjaja.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void PopulateInfos()
        {
            sveKontrole = DTOManager.GetSigurnosneKontroleInfos()
                                    .OrderBy(k => k.Id)
                                    .ToList();

            dgvSigurnost.Rows.Clear();

            foreach (SigurnosnaKontrolaPregled sk in sveKontrole)
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
    }
}
