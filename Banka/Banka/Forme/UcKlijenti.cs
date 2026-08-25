using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banka.DTOs;

namespace Banka.Forme
{
    public partial class UcKlijenti : UserControl
    {
        private int? selektovaniKlijentId = null;
        private string selektovaniKlijentName = "";

        public UcKlijenti()
        {
            InitializeComponent();

            cmbTipKlijenta.SelectedIndex = 0;
            cmbTipFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void cmbTipKlijenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipKlijenta.SelectedItem == null)
                return;

            if (cmbTipKlijenta.SelectedItem.ToString() == "Fizičko lice")
            {
                panelFizicko.Visible = true;
                panelPravno.Visible = false;
                panelFizicko.BringToFront();
            }
            else if (cmbTipKlijenta.SelectedItem.ToString() == "Pravno lice")
            {
                panelFizicko.Visible = false;
                panelPravno.Visible = true;
                panelPravno.BringToFront();
            }
        }

        private void PopulateInfos()
        {
            dgvKlijenti.Rows.Clear();

            List<KlijentPregled> klijenti = DTOManager.GetKlijentInfos();

            foreach (KlijentPregled kp in klijenti)
            {
                dgvKlijenti.Rows.Add(
                    kp.KlijentId.ToString(),
                    kp.TipKlijenta ?? "",
                    kp.ImeNaziv ?? "",
                    kp.JMBGPIB ?? "",
                    kp.Grad ?? "",
                    kp.Telefon ?? "",
                    kp.Status ?? ""
                );
            }

            dgvKlijenti.Refresh();
        }

        private void PopulateData(KlijentBasic kb)
        {
            if (kb == null)
                return;

            txtAdresa.Text = kb.Adresa ?? "";
            txtGrad.Text = kb.Grad ?? "";
            txtTelefon.Text = kb.Telefon ?? "";
            txtEmail.Text = kb.Email ?? "";
            txtKomentar.Text = kb.Komentar ?? "";

            if (cmbStatus.Items.Contains(kb.Status))
                cmbStatus.SelectedItem = kb.Status;

            txtIme.Clear();
            txtPrezime.Clear();
            txtJMBG.Clear();
            txtBrojLicneKarte.Clear();

            txtNazivFirme.Clear();
            txtPIB.Clear();

            if (kb.TipKlijenta == "fizicko")
            {
                cmbTipKlijenta.SelectedItem = "Fizičko lice";

                txtIme.Text = kb.Ime ?? "";
                txtPrezime.Text = kb.Prezime ?? "";
                txtJMBG.Text = kb.JMBG ?? "";
                txtBrojLicneKarte.Text = kb.BrojLicneKarte ?? "";

                if (kb.DatumRodjenja.HasValue)
                    dateTimePicker1.Value = kb.DatumRodjenja.Value;
            }
            else if (kb.TipKlijenta == "pravno")
            {
                cmbTipKlijenta.SelectedItem = "Pravno lice";

                txtNazivFirme.Text = kb.NazivFirme ?? "";
                txtPIB.Text = kb.PIB ?? "";
            }
        }

        private KlijentBasic ProcitajPodatkeSaForme()
        {
            KlijentBasic kb = new KlijentBasic();

            if (selektovaniKlijentId.HasValue)
                kb.KlijentId = selektovaniKlijentId.Value;

            if (cmbTipKlijenta.SelectedItem.ToString() == "Fizičko lice")
            {
                kb.TipKlijenta = "fizicko";

                kb.Ime = txtIme.Text.Trim();
                kb.Prezime = txtPrezime.Text.Trim();
                kb.JMBG = txtJMBG.Text.Trim();
                kb.BrojLicneKarte = txtBrojLicneKarte.Text.Trim();
                kb.DatumRodjenja = dateTimePicker1.Value;
            }
            else
            {
                kb.TipKlijenta = "pravno";

                kb.NazivFirme = txtNazivFirme.Text.Trim();
                kb.PIB = txtPIB.Text.Trim();
            }

            kb.Adresa = txtAdresa.Text.Trim();
            kb.Grad = txtGrad.Text.Trim();
            kb.Telefon = txtTelefon.Text.Trim();
            kb.Email = txtEmail.Text.Trim();
            kb.Status = cmbStatus.SelectedItem?.ToString();
            kb.Komentar = txtKomentar.Text.Trim();

            return kb;
        }

        private bool ValidacijaKlijenta()
        {
            if (cmbTipKlijenta.SelectedItem == null)
            {
                MessageBox.Show("Izaberite tip klijenta.");
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status klijenta.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                MessageBox.Show("Unesite adresu.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGrad.Text))
            {
                MessageBox.Show("Unesite grad.");
                return false;
            }

            if (cmbTipKlijenta.SelectedItem.ToString() == "Fizičko lice")
            {
                if (string.IsNullOrWhiteSpace(txtIme.Text) ||
                    string.IsNullOrWhiteSpace(txtPrezime.Text) ||
                    string.IsNullOrWhiteSpace(txtJMBG.Text))
                {
                    MessageBox.Show(
                        "Unesite ime, prezime i JMBG fizičkog lica."
                    );

                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtNazivFirme.Text) ||
                    string.IsNullOrWhiteSpace(txtPIB.Text))
                {
                    MessageBox.Show(
                        "Unesite naziv firme i PIB."
                    );

                    return false;
                }
            }

            return true;
        }

        private void OcistiFormu()
        {
            selektovaniKlijentId = null;

            dgvKlijenti.ClearSelection();

            cmbTipKlijenta.Enabled = true;
            cmbTipKlijenta.SelectedIndex = 0;

            txtIme.Clear();
            txtPrezime.Clear();
            txtJMBG.Clear();
            txtBrojLicneKarte.Clear();

            txtNazivFirme.Clear();
            txtPIB.Clear();

            txtAdresa.Clear();
            txtGrad.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtKomentar.Clear();

            cmbStatus.SelectedIndex = 0;

            dateTimePicker1.Value = DateTime.Today;
        }

        private void UcKlijenti_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            OcistiFormu();

            txtIme.Focus();
        }

        private async void dgvKlijenti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object vrednostId = dgvKlijenti.Rows[e.RowIndex].Cells[0].Value;
            object selektovaniIme = dgvKlijenti.Rows[e.RowIndex].Cells[2].Value;
            if (selektovaniIme == null)
                return;
            
            if (vrednostId == null)
                return;

            selektovaniKlijentName = selektovaniIme.ToString();
            if (int.TryParse(vrednostId.ToString(), out int idKlijenta))
            {
                selektovaniKlijentId = idKlijenta;

                cmbTipKlijenta.Enabled = false;

                KlijentBasic kb = await DTOManager.GetKlijentBasic(idKlijenta);

                PopulateData(kb);
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaKlijenta())
                return;

            if (selektovaniKlijentId != null)
            {
                MessageBox.Show("Sačuvaj služi za dodavanje novog klijenta. ");

                return;
            }

            KlijentBasic kb = ProcitajPodatkeSaForme();

            bool success = await DTOManager.AddKlijent(kb);

            if (success)
            {
                MessageBox.Show(
                    "Klijent je uspešno dodat.", 
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
            if (!selektovaniKlijentId.HasValue)
            {
                MessageBox.Show(
                    "Prvo izaberite klijenta iz tabele.",
                    "Izmena klijenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            if (!ValidacijaKlijenta())
                return;

            KlijentBasic kb = ProcitajPodatkeSaForme();

            bool success = await DTOManager.UpdateKlijentBasic(kb);

            if (success)
            {
                MessageBox.Show(
                    "Podaci o klijentu su uspešno izmenjeni.",
                    "Uspešna promena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PopulateInfos();

                KlijentBasic osvezeni = await DTOManager.GetKlijentBasic(selektovaniKlijentId.Value);

                PopulateData(osvezeni);
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (!selektovaniKlijentId.HasValue)
            {
                MessageBox.Show(
                    "Prvo izaberite klijenta iz tabele.",
                    "Brisanje klijenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete izabranog klijenta?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (rezultat != DialogResult.Yes)
                return;

            bool success = await DTOManager.DeleteKlijent(selektovaniKlijentId.Value);

            if (success)
            {
                MessageBox.Show(
                    "Klijent je uspešno obrisan.",
                    "Uspeh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PopulateInfos();

                OcistiFormu();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            OcistiFormu();
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            if (dgvKlijenti.SelectedRows.Count > 0)
            {
                // Uzimamo ID i ime klijenta iz selektovanog reda u DataGridView-u
                //int klijentId = Convert.ToInt32(dgvKlijenti.SelectedRows[0].Cells["Id"].Value);
                //string klijentIme = dgvKlijenti.SelectedRows[0].Cells["ImeNaziv"].Value.ToString();

                // Otvaramo UcRacuni i prosleđujemo ID i Ime
                UcRacuni ucRacuni = new UcRacuni(selektovaniKlijentId, selektovaniKlijentName);

                Panel panelMain = this.Parent as Panel;
                if (panelMain != null)
                {
                    panelMain.Controls.Clear();
                    ucRacuni.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(ucRacuni);
                }
            }
            else
            {
                MessageBox.Show("Molimo vas da prvo izaberete klijenta iz tabele.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
