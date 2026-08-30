using Banka.DTOs;
using Banka.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Banka.Forme
{
    public partial class UcKrediti : UserControl
    {
        public int? selektovanKredit = null;
        List<KreditPregled> sviKrediti = DTOManager.GetKreditiInfos();
        public UcKrediti()
        {
            InitializeComponent();
            cmbKlijent.SelectedIndex = -1;
            cmbKlijentFilter.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbStatusFilter.SelectedIndex = 0;
            cmbValuta.SelectedIndex = 0;
            cmbKlijent.SelectedIndex = -1;
            cmbRacun.SelectedIndex = -1;
        }

        private void PopulateInfos()
        {
            sviKrediti = DTOManager.GetKreditiInfos();
            dgvKrediti.Rows.Clear();

            foreach (KreditPregled kredit in sviKrediti)
            {
                string klijent = "";
                if (kredit.Klijent is FizickoLice f)
                    klijent = f.JMBG;
                else if (kredit.Klijent is PravnoLice p)
                    klijent = p.PIB;

                dgvKrediti.Rows.Add(
                    kredit.Id,
                    kredit.StatusKredita ?? "",
                    kredit.Namena ?? "",
                    kredit.Iznos.ToString("N2"),
                    kredit.Valuta ?? "",
                    kredit.KamatnaStopa.ToString() ?? "",
                    kredit.MesecnaRata.ToString("N2") ?? "",
                    kredit.DatumOdobrenja.ToString() ?? "",
                    kredit.DatumDospeca.ToString() ?? "",
                    kredit.Racun.BrojRacuna ?? "",
                    klijent 
                );
            }

            dgvKrediti.ClearSelection();
            selektovanKredit = null;
            dgvKrediti.Refresh();
        }

        private void OcistiFormu()
        {
            selektovanKredit = null;
            dgvKrediti.ClearSelection();
            cmbKlijent.SelectedIndex = -1;
            cmbRacun.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbValuta.SelectedIndex = -1;
            txtIznos.Clear();
            txtNamena.Clear();
            txtKamatnaStopa.Clear();
            txtRokOtplate.Clear();
            txtKomentar.Clear();
            dtpDatumOdobrenja.Value = DateTime.Today;
        }

        private void PopulateKlijentiCombo()
        {
            cmbKlijent.Items.Clear();
            cmbKlijentFilter.Items.Clear();

            List<KlijentPregled> klijenti = DTOManager.GetKlijentInfos();

            cmbKlijentFilter.Items.Add("Svi");
            cmbKlijentFilter.SelectedIndex = 0;
            foreach (KlijentPregled klijent in klijenti)
            {
                cmbKlijent.Items.Add(klijent.JMBGPIB);
                cmbKlijentFilter.Items.Add(klijent.JMBGPIB);
            }
        }

        private void PopulateRacuniCombo()
        {
            cmbRacun.Items.Clear();

            List<RacunPregled> racuni = DTOManager.GetRacunInfo();

            foreach (RacunPregled racun in racuni)
            {
                string brojRacuna = racun.BrojRacuna.ToString();
                cmbRacun.Items.Add(brojRacuna);
            }
        }

        private void UcKrediti_Load(object sender, System.EventArgs e)
        {
            PopulateInfos();
            PopulateKlijentiCombo();
            PopulateRacuniCombo();
            OcistiFormu();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void PopulateData(KreditBasic kb)
        {
            if (kb == null)
                return;

            txtIznos.Text = kb.Iznos.ToString("N2");
            txtNamena.Text = kb.Namena ?? "";
            txtKomentar.Text = kb.Komentar ?? "";
            txtKamatnaStopa.Text = kb.KamatnaStopa?.ToString() ?? "";
            txtRokOtplate.Text = kb.RokOtplate?.ToString() ?? "";

            if (kb.DatumOdobrenja.HasValue)
                dtpDatumOdobrenja.Value = kb.DatumOdobrenja.Value;

            if (kb.Valuta != null && cmbValuta.Items.Contains(kb.Valuta))
                cmbValuta.SelectedItem = kb.Valuta;

            if (kb.StatusKredita != null && cmbStatus.Items.Contains(kb.StatusKredita))
                cmbStatus.SelectedItem = kb.StatusKredita;

            string brojRacuna = kb.Racun != null ? kb.Racun.BrojRacuna : "";
            if (!string.IsNullOrEmpty(brojRacuna) && cmbRacun.Items.Contains(brojRacuna))
                cmbRacun.SelectedItem = brojRacuna;

            string identificatorKlijenta = "";
            if (kb.Klijent is FizickoLice f)
                identificatorKlijenta = f.JMBG;
            else if (kb.Klijent is PravnoLice p)
                identificatorKlijenta = p.PIB;
            else
                MessageBox.Show(kb.Klijent.Email);

            if (!string.IsNullOrEmpty(identificatorKlijenta) && cmbKlijent.Items.Contains(identificatorKlijenta))
                cmbKlijent.SelectedItem = identificatorKlijenta;
        }

        private async void dgvKrediti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object vrednostId = dgvKrediti.Rows[e.RowIndex].Cells[0].Value;
            if (vrednostId == null)
                return;

            if (int.TryParse(vrednostId.ToString(), out int idKredita))
            {
                selektovanKredit = idKredita;
                KreditBasic kb = await DTOManager.GetKreditBasic(idKredita);

                PopulateData(kb);
            }
        }

        private bool ValidacijaKredita()
        {
            if (cmbKlijent.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Klijenta.");
                return false;
            }

            if (cmbRacun.SelectedItem == null)
            {
                MessageBox.Show("Izaberite Racun.");
                return false;
            }
            string selektovaniKlijent = cmbKlijent.SelectedItem.ToString();
            string selektovaniRacun = cmbRacun.SelectedItem.ToString();

            bool racunPripadaKlijentu = DTOManager.ProveriDaLiRacunPripadaKlijentu(selektovaniKlijent, selektovaniRacun);

            if (!racunPripadaKlijentu)
            {
                MessageBox.Show("Izabrani racun ne pripada selektovanom klijentu.");
                return false;
            }

            if (string.IsNullOrEmpty(txtIznos.Text))
            {
                MessageBox.Show("Unesite Iznos kredita.");
                return false;
            }

            if (string.IsNullOrEmpty(cmbValuta.Text))
            {
                MessageBox.Show("Izaberite Valutu.");
                return false;
            }

            if (string.IsNullOrEmpty(txtKamatnaStopa.Text))
            {
                MessageBox.Show("Unesite kamatnu stopu.");
                return false;
            }
            double kStopa = double.Parse(txtKamatnaStopa.Text);
            if(kStopa <= 0)
            {
                MessageBox.Show("Kamatna stopa mora biti veca od 0!");
                return false;
            }

            if (string.IsNullOrEmpty(txtRokOtplate.Text))
            {
                MessageBox.Show("Unesite rok otplate.");
                return false;
            }
            double rok = double.Parse(txtRokOtplate.Text);
            if (rok < 1)
            {
                MessageBox.Show("Rok otplate mora biti minimun 1 mesec");
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status.");
                return false;
            }

            if (string.IsNullOrEmpty(txtNamena.Text))
            {
                MessageBox.Show("Unesite namenu.");
                return false;
            }

            return true;
        }

        private KreditBasic ProcitajPodatkeSaForme()
        {
            KreditBasic kb = new KreditBasic();

            if (selektovanKredit.HasValue)
                kb.Id = selektovanKredit.Value;

            kb.Namena = txtNamena.Text.Trim();
            kb.Komentar = txtKomentar.Text.Trim();

            if (double.TryParse(txtIznos.Text, out double iznos))
                kb.Iznos = iznos;

            if (double.TryParse(txtKamatnaStopa.Text, out double kamatnaStopa))
                kb.KamatnaStopa = kamatnaStopa;

            if (int.TryParse(txtRokOtplate.Text, out int rokOtplate))
                kb.RokOtplate = rokOtplate;

            kb.DatumOdobrenja = dtpDatumOdobrenja.Value;

            if (cmbValuta.SelectedItem != null)
                kb.Valuta = cmbValuta.SelectedItem.ToString();

            if (cmbStatus.SelectedItem != null)
                kb.StatusKredita = cmbStatus.SelectedItem.ToString();

            // Za račun i klijenta čitamo selektovane stringove (Broj računa i JMBG/PIB)
            // Napomena: Pri čuvanju u bazu preko DTOManager-a u bazi tražiš objekte po ovim identifikatorima
            if (cmbRacun.SelectedItem != null)
                kb.BrojRacuna = cmbRacun.SelectedItem.ToString();

            if (cmbKlijent.SelectedItem != null)
                kb.KlijentIdentifikator = cmbKlijent.SelectedItem.ToString();

            return kb;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaKredita())
                return;

            if (selektovanKredit != null)
            {
                MessageBox.Show("Sačuvaj služi za dodavanje novog kredita");
                return;
            }

            KreditBasic kb = ProcitajPodatkeSaForme();

            bool success = await DTOManager.AddKredit(kb);
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

        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!selektovanKredit.HasValue)
            {
                MessageBox.Show("Molimo vas da izaberete kredit koji želite da izmenite.",
                                "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIznos.Text) ||
                cmbRacun.SelectedItem == null ||
                cmbKlijent.SelectedItem == null)
            {
                MessageBox.Show("Molimo vas da popunite sva obavezna polja (Iznos, Račun, Klijent).",
                                "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string izabraniKlijent = cmbKlijent.SelectedItem.ToString();
            string izabraniRacun = cmbRacun.SelectedItem.ToString();

            if (!DTOManager.ProveriDaLiRacunPripadaKlijentu(izabraniKlijent, izabraniRacun))
            {
                MessageBox.Show("Izabrani račun ne pripada izabranom klijentu!",
                                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KreditBasic kb = ProcitajPodatkeSaForme();

            bool success = await DTOManager.UpdateKredit(kb);

            if (success)
            {
                MessageBox.Show("Kredit je uspešno izmenjen!",
                                "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopulateInfos();
                OcistiFormu();
            }
        }

        private void PrimeniFiltere()
        {
            if (sviKrediti == null)
                return;

            IEnumerable<KreditPregled> rezultat = sviKrediti;

            // 1. po klijentu jmbg/pib
            string pretragaKlijent = cmbKlijentFilter.Text?.Trim();

            if (!string.IsNullOrWhiteSpace(pretragaKlijent) && pretragaKlijent != "Svi")
            {
                rezultat = rezultat.Where(k =>
                {
                    if (k.Klijent is FizickoLice f)
                        return string.Equals(f.JMBG, pretragaKlijent, StringComparison.OrdinalIgnoreCase);
                    if (k.Klijent is PravnoLice p)
                        return string.Equals(p.PIB, pretragaKlijent, StringComparison.OrdinalIgnoreCase);

                    return false;
                });
            }

            // 2. po statusu
            string selektovaniStatus = cmbStatusFilter.SelectedItem?.ToString() ?? cmbStatusFilter.Text;

            if (!string.IsNullOrWhiteSpace(selektovaniStatus) && selektovaniStatus != "Svi")
            {
                rezultat = rezultat.Where(k =>
                    string.Equals(k.StatusKredita, selektovaniStatus, StringComparison.OrdinalIgnoreCase));
            }

            dgvKrediti.Rows.Clear();

            foreach (KreditPregled kredit in rezultat)
            {
                string klijentIdentifikator = kredit.Klijent is FizickoLice f ? f.JMBG :
                                             (kredit.Klijent is PravnoLice p ? p.PIB : "");

                dgvKrediti.Rows.Add(
                    kredit.Id,
                    kredit.StatusKredita ?? "",
                    kredit.Namena ?? "",
                    kredit.Iznos,
                    kredit.Valuta ?? "",
                    kredit.KamatnaStopa.HasValue ? kredit.KamatnaStopa.Value.ToString() : "",
                    kredit.MesecnaRata,
                    kredit.DatumOdobrenja.HasValue ? kredit.DatumOdobrenja.Value.ToShortDateString() : "",
                    kredit.DatumDospeca.HasValue ? kredit.DatumDospeca.Value.ToShortDateString() : "",
                    kredit.Racun != null ? kredit.Racun.BrojRacuna : "",
                    klijentIdentifikator
                );
            }

            dgvKrediti.ClearSelection();
            selektovanKredit = null;
            dgvKrediti.Refresh();
        }

        private void cmbKlijentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (!selektovanKredit.HasValue)
            {
                MessageBox.Show(
                    "Prvo izaberite kredit iz tabele.",
                    "Brisanje kredita",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete izabrani kredit?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (rezultat != DialogResult.Yes)
                return;

            bool success = await DTOManager.DeleteKredit(selektovanKredit.Value);

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
    }
}
