using Banka.Entiteti;
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
    //info za datagridview
    public class RacunPregled
    {
        public string BrojRacuna { get; set; }
        public string TipRacuna { get; set; }
        public string StatusRacuna { get; set; }
        public string Valuta { get; set; }
        public string ImeNaziv{ get; set; }
        public int KlijentId { get; set; }
        public RacunPregled() { }
        public RacunPregled(
            string brojRacuna,
            string tipRacuna,
            string statusRacuna,
            string valuta,
            //Klijent klijent,
            string imeNaziv,
            int klijentId
            ) 
        {
            BrojRacuna = brojRacuna;
            TipRacuna = tipRacuna;
            StatusRacuna = statusRacuna;
            Valuta = valuta;
            ImeNaziv = imeNaziv;
            KlijentId = klijentId;
        }

    }
    public class RacunBasic
    {
        public string BrojRacuna { get; set; }
        public string Klijent { get; set; }

        
        public string TipRacuna { get; set; }
        public string Valuta { get; set; }
        public double TrenutnoStanje { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public string StatusRacuna { get; set; }
        public double? KamatnaStopa { get; set; }
        public double? DozvoljeniMinus { get; set; }
        public string Komentar { get; set; }

        // tekuci
        public string MogucnostPlatnihKartica { get; set; }
        public int? MesecniLimitTransakcija { get; set; }
        //povezani paketi?

        // stedni
        public double MinimalniIznosZaOtvaranje { get; set; }
        public string UsloviPodizanjaSredstava { get; set; }
        public string Frekvencija { get; set; }
        public double? BonusiZaDugorocnuStednju { get; set; }

        // devizni
        //dozvoljene valute?
        public string NamenaDevizni { get; set; }
        public string OgranicenjaDeviznihPropisa { get; set; }
        public double? KursnaRazlikaKonverzije { get; set; }

        // ziro
        public string NamenaZiro { get; set; }
        public string EBankarstvoZaFirme { get; set; }
        public double? LimitMasovnihPlacanja { get; set; }
        public string Integracija { get; set; }
    }

    public class TransakcijaBasic
    {
        public int KodTransakcije { get; set; }
        public string BrojRacunaPosiljalac { get; set; }
        public string TipTransakcije { get; set; }
        public double Iznos { get; set; }
        public string Valuta { get; set; }
        public string Status { get; set; }
        public DateTime? Datum { get; set; }
        public string Vreme { get; set; }
        public string  BrojRacunaPrimalac { get; set; }

        //nullable type shi
        public string Referenca { get; set; }
        public string PodacioOPrimaocu { get; set; }
        public string Komentar { get; set; }
        public string Opis { get; set; }
    }

    public class TransakcijaPregled
    {
        public int KodTransakcije { get; set; }
        public string BrojRacunaPosiljalac { get; set; }
        public string TipTransakcije { get; set; }
        public double Iznos { get; set; }
        public string Valuta { get; set; }
        public string Status { get; set; }
        public DateTime? Datum { get; set; }
        public string Vreme { get; set; }
        public string BrojRacunaPrimalac { get; set; }
        public TransakcijaPregled(
            int kodTransakcije,
            string brojRacunaPosiljalac,
            string tipTransaakcije,
            string valuta,
            double iznos,
            string status,
            DateTime datum,
            string vreme,
            string brojRacunaPrimalac
        )
        {
            KodTransakcije = kodTransakcije;
            BrojRacunaPosiljalac = brojRacunaPosiljalac;
            TipTransakcije = tipTransaakcije;
            Valuta = valuta;
            Iznos = iznos;
            Status = status;
            Datum = datum;
            Vreme = vreme;
            BrojRacunaPrimalac = brojRacunaPrimalac;
        }
    }

    public class SigurnosnaKontrolaPregled
    {
        public int Id { get; set; }

        public int KlijentId { get; set; }
        public string KlijentNaziv { get; set; }

        public string BrojRacuna { get; set; }

        public string TipDogadjaja { get; set; }
        public DateTime Datum { get; set; }
        public string Vreme { get; set; }

        public string IpAdresa { get; set; }
        public string Status { get; set; }

        public SigurnosnaKontrolaPregled() {}

        public SigurnosnaKontrolaPregled(
            int id,
            int klijentId,
            string klijentNaziv,
            string brojRacuna,
            string tipDogadjaja,
            DateTime datum,
            string vreme,
            string ipAdresa,
            string status)
        {
            Id = id;
            KlijentId = klijentId;
            KlijentNaziv = klijentNaziv;
            BrojRacuna = brojRacuna;
            TipDogadjaja = tipDogadjaja;
            Datum = datum;
            Vreme = vreme;
            IpAdresa = ipAdresa;
            Status = status;
        }
    }

    public class SigurnosnaKontrolaBasic
    {
        public int Id { get; set; }

        public int KlijentId { get; set; }
        public string BrojRacuna { get; set; }

        public string TipDogadjaja { get; set; }

        public DateTime Datum { get; set; }
        public string Vreme { get; set; }

        public string IpAdresa { get; set; }
        public string PodaciOUredjaju { get; set; }

        public string Status { get; set; }
        public string Opis { get; set; }

        public SigurnosnaKontrolaBasic() {}
    }


    //KREDIT
}
