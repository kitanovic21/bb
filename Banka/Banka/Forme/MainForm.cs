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
    // Glavna forma aplikacije koja deluje kao kontejner i navigacija za sve pod-ekrane (UserControl-e)
    public partial class MainForm : Form
    {
        // Deklaracija privatnih polja za UserControl ekrane (Lazy loading / Keširanje kontrola).
        // Na početku su sve vrednosti 'null', a instanciraju se tek kada korisnik prvi put klikne na odgovarajuće dugme.
        private UcKlijenti ucKlijenti;
        private UcRacuni ucRacuni;
        private UcTransakcije ucTransakcije;
        private UcKrediti ucKrediti;
        private UcDepoziti ucDepoziti;
        private UcKamate ucKamate;
        private UcSigurnost ucSigurnost;

        // Konstruktor glavne forme
        public MainForm()
        {
            // Inicijalizuje sve vizuelne komponente kreirane kroz Windows Forms Designer (dugmad, panele, itd.)
            InitializeComponent();
        }

        // Pomoćna metoda koja menja trenutno prikazani ekran (UserControl) u glavnom panelu
        private void PrikaziKontrolu(UserControl kontrola)
        {
            // Uklanja sve prethodne kontrole iz panela kako se novi ekran ne bi iscrtavao preko starog
            panelContent.Controls.Clear();

            // Rasteže novu kontrolu tako da u potpunosti popuni širinu i visinu roditeljskog panela (panelContent)
            kontrola.Dock = DockStyle.Fill;

            // Fizički dodaje prosleđenu kontrolu u kolekciju kontrola panela
            panelContent.Controls.Add(kontrola);

            // Pomera kontrolu na sam vrh vizuelnog prikaza (Z-ose) kako bi bila sigurno vidljiva
            kontrola.BringToFront();
        }

        // Pomoćna metoda za vizuelno označavanje aktivnog dugmeta u navigacionom meniju
        private void PostaviAktivnoDugme(Button aktivnoDugme)
        {
            // Pravi niz sa svim dugmićima koji se nalaze u navigacionom meniju
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

            // Prolazi kroz svako dugme u nizu i vraća mu podrazumevani (neaktivni) izgled
            foreach (Button dugme in dugmici)
            {
                dugme.BackColor = Color.FromArgb(24, 44, 73); // Tamnoplava pozadina za neaktivno dugme
                dugme.ForeColor = Color.White;                // Beli tekst
            }

            // Postavlja svetliju plavu boju pozadine samo za ono dugme koje je trenutno kliknuto/aktivno
            aktivnoDugme.BackColor = Color.FromArgb(42, 78, 121);
        }

        // Događaj na klik dugmeta "Klijenti"
        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            // Ako ekran za klijente još uvek nije kreiran (prvi klik), instanciraj ga
            if (ucKlijenti == null)
                ucKlijenti = new UcKlijenti();

            // Prikaži ekran za klijente u glavnom panelu
            PrikaziKontrolu(ucKlijenti);

            // Označi dugme "Klijenti" kao aktivno u meniju
            PostaviAktivnoDugme(btnKlijenti);
        }

        // Događaj na klik dugmeta "Računi"
        private void btnRacuni_Click(object sender, EventArgs e)
        {
            // Ako ekran za račune još uvek nije kreiran, instanciraj ga
            if (ucRacuni == null)
                ucRacuni = new UcRacuni();

            // Prikaži ekran za račune u glavnom panelu
            PrikaziKontrolu(ucRacuni);

            // Označi dugme "Računi" kao aktivno u meniju
            PostaviAktivnoDugme(btnRacuni);
        }

        // Događaj na klik dugmeta "Transakcije"
        private void btnTransakcije_Click(object sender, EventArgs e)
        {
            // Ako ekran za transakcije još uvek nije kreiran, instanciraj ga
            if (ucTransakcije == null)
                ucTransakcije = new UcTransakcije();

            // Prikaži ekran za transakcije u glavnom panelu
            PrikaziKontrolu(ucTransakcije);

            // Označi dugme "Transakcije" kao aktivno u meniju
            PostaviAktivnoDugme(btnTransakcije);
        }

        // Događaj na klik dugmeta "Krediti"
        private void btnKrediti_Click(object sender, EventArgs e)
        {
            // Ako ekran za kredite još uvek nije kreiran, instanciraj ga
            if (ucKrediti == null)
                ucKrediti = new UcKrediti();

            // Prikaži ekran za kredite u glavnom panelu
            PrikaziKontrolu(ucKrediti);

            // Označi dugme "Krediti" kao aktivno u meniju
            PostaviAktivnoDugme(btnKrediti);
        }

        // Događaj na klik dugmeta "Depoziti"
        private void btnDepoziti_Click(object sender, EventArgs e)
        {
            // Ako ekran za depozite još uvek nije kreiran, instanciraj ga
            if (ucDepoziti == null)
                ucDepoziti = new UcDepoziti();

            // Prikaži ekran za depozite u glavnom panelu
            PrikaziKontrolu(ucDepoziti);

            // Označi dugme "Depoziti" kao aktivno u meniju
            PostaviAktivnoDugme(btnDepoziti);
        }

        // Događaj na klik dugmeta "Kamate"
        private void btnKamate_Click(object sender, EventArgs e)
        {
            // Ako ekran za kamate još uvek nije kreiran, instanciraj ga
            if (ucKamate == null)
                ucKamate = new UcKamate();

            // Prikaži ekran za kamate u glavnom panelu
            PrikaziKontrolu(ucKamate);

            // Označi dugme "Kamate" kao aktivno u meniju
            PostaviAktivnoDugme(btnKamate);
        }

        // Događaj na klik dugmeta "Sigurnost"
        private void btnSigurnost_Click(object sender, EventArgs e)
        {
            // Ako ekran za sigurnost još uvek nije kreiran, instanciraj ga
            if (ucSigurnost == null)
                ucSigurnost = new UcSigurnost();

            // Prikaži ekran za sigurnost u glavnom panelu
            PrikaziKontrolu(ucSigurnost);

            // Označi dugme "Sigurnost" kao aktivno u meniju
            PostaviAktivnoDugme(btnSigurnost);
        }
    }
}