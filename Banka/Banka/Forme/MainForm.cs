using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banka.Forme
{
    public partial class MainForm : Form
    {
        private UcKlijenti ucKlijenti;
        private UcRacuni ucRacuni;
        private UcTransakcije ucTransakcije;
        private UcKrediti ucKrediti;
        private UcDepoziti ucDepoziti;
        private UcKamate ucKamate;
        private UcSigurnost ucSigurnost;

        public MainForm()
        {
            InitializeComponent();
        }

        private void PrikaziKontrolu(UserControl kontrola)
        {
            panelContent.Controls.Clear();

            kontrola.Dock = DockStyle.Fill;
            panelContent.Controls.Add(kontrola);

            kontrola.BringToFront();
        }

        private void PostaviAktivnoDugme(Button aktivnoDugme)
        {
            Button[] dugmici =
            {
                btnKlijenti,
                btnRacuni,
                btnTransakcije,
                btnKrediti,
                btnDepoziti,
                btnKamate,
                btnSigurnost
            };

            foreach (Button dugme in dugmici)
            {
                dugme.BackColor = Color.FromArgb(24, 44, 73);
                dugme.ForeColor = Color.White;
            }

            aktivnoDugme.BackColor = Color.FromArgb(42, 78, 121);
        }

        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            if (ucKlijenti == null)
                ucKlijenti = new UcKlijenti();

            PrikaziKontrolu(ucKlijenti);
            PostaviAktivnoDugme(btnKlijenti);
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            if (ucRacuni == null)
                ucRacuni = new UcRacuni();

            PrikaziKontrolu(ucRacuni);
            PostaviAktivnoDugme(btnRacuni);
        }

        private void btnTransakcije_Click(object sender, EventArgs e)
        {
            if (ucTransakcije == null)
                ucTransakcije = new UcTransakcije();

            PrikaziKontrolu(ucTransakcije);
            PostaviAktivnoDugme(btnTransakcije);
        }

        private void btnKrediti_Click(object sender, EventArgs e)
        {
            if (ucKrediti == null)
                ucKrediti = new UcKrediti();

            PrikaziKontrolu(ucKrediti);
            PostaviAktivnoDugme(btnKrediti);
        }

        private void btnDepoziti_Click(object sender, EventArgs e)
        {
            if (ucDepoziti == null)
                ucDepoziti = new UcDepoziti();

            PrikaziKontrolu(ucDepoziti);
            PostaviAktivnoDugme(btnDepoziti);
        }

        private void btnKamate_Click(object sender, EventArgs e)
        {
            if (ucKamate == null)
                ucKamate = new UcKamate();

            PrikaziKontrolu(ucKamate);
            PostaviAktivnoDugme(btnKamate);
        }

        private void btnSigurnost_Click(object sender, EventArgs e)
        {
            if (ucSigurnost == null)
                ucSigurnost = new UcSigurnost();

            PrikaziKontrolu(ucSigurnost);
            PostaviAktivnoDugme(btnSigurnost);
        }
    }
}
