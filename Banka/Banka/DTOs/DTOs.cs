using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.DTOs
{
    //Ovo vam je ono sto ce da bude u dataGridView
    public class KlijentPregled
    {
        public int KlijentId { get; set; }
        public string TipKlijenta { get; set; }
        public string ImeNaziv { get; set; }
        public string JMBGPIB { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public string Status { get; set; }

        public KlijentPregled(
            int klijentId,
            string tipKlijenta,
            string imeNaziv,
            string jmbgPib,
            string grad,
            string telefon,
            string status)
        {
            KlijentId = klijentId;
            TipKlijenta = tipKlijenta;
            ImeNaziv = imeNaziv;
            JMBGPIB = jmbgPib;
            Grad = grad;
            Telefon = telefon;
            Status = status;
        }
    }

    //A ovo su vam sve informacije koje treba da budu na toj stranici
    public class KlijentBasic
    {
        public int KlijentId { get; set; }

        // zajednički podaci
        public string TipKlijenta { get; set; }
        public string Status { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Email { get; set; }
        public string Komentar { get; set; }
        public string Telefon { get; set; }

        // fizičko lice
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string BrojLicneKarte { get; set; }
        public DateTime? DatumRodjenja { get; set; }

        // pravno lice
        public string NazivFirme { get; set; }
        public string PIB { get; set; }

        public KlijentBasic()
        {
        }
    }
}
