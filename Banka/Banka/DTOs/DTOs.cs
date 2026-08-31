using Banka.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banka.DTOs
{
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

    //DEPOZIT
    public class DepozitPregled
    {
        public int Id { get; set; }
        public int KlijentId { get; set; }
        public string KlijentNaziv { get; set; }
        public double Iznos { get; set; }
        public DateTime DatumPocetka { get; set; }
        public string Valuta { get; set; }
        public string Status { get; set; }

        public DepozitPregled() {}
    }

    public class DepozitBasic   
    {
        public int Id { get; set; }
        public int KlijentId { get; set; }
        public string BrojRacuna { get; set; }

        public double Iznos { get; set; }
        public string Komentar { get; set; }
        public int? PeriodOrocenja { get; set; }
        public DateTime DatumPocetka { get; set; }
        public string Valuta { get; set; }
        public double? OcekivanaKamata { get; set; }
        public DateTime? DatumIsteka { get; set; }
        public string Status { get; set; }
        public double? KamatnaStopa { get; set; }

        public DepozitBasic() {}
    }

    //TRANSKACIJE
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

    //KREDIT
    public class KreditBasic
    {
        public int Id { get; set; }
        public string StatusKredita { get; set; }
        public string Namena { get; set; }
        public string Komentar { get; set; }
        public double Iznos { get; set; }
        public string Valuta { get; set; }
        public double? KamatnaStopa { get; set; }
        public int? RokOtplate { get; set; }
        public DateTime? DatumDospeca { get; set; }
        public DateTime? DatumOdobrenja { get; set; }
        public string BrojRacuna { get; set; }
        public string KlijentIdentifikator { get; set; }
        public Racun Racun { get; set; }
        public Klijent Klijent { get; set; }
        public double MesecnaRata { get; set; }
    }

    public class KreditPregled
    {
        public int Id { get; set; }
        public string StatusKredita { get; set; }
        public string Namena { get; set; }
        public double Iznos { get; set; }
        public string Valuta { get; set; }
        public double? KamatnaStopa { get; set; }
        public double MesecnaRata { get; set; }
        public DateTime? DatumDospeca { get; set; }
        public DateTime? DatumOdobrenja { get; set; }
        public Racun Racun { get; set; }
        public Klijent Klijent { get; set; }

        public KreditPregled(
                    int id,
                    string statusKredita,
                    string namena,
                    double iznos,
                    string valuta,
                    double kamatnaStopa,
                    DateTime datumDospeca,
                    DateTime datumOdobrenja,
                    Racun racun,
                    Klijent klijent,
                    double mesecnaRata
                )
        {
            Id = id;
            StatusKredita = statusKredita;
            Namena = namena;
            Iznos = iznos;
            Valuta = valuta;
            KamatnaStopa = kamatnaStopa;
            DatumDospeca = datumDospeca;
            DatumOdobrenja = datumOdobrenja;
            Racun = racun;
            Klijent = klijent;
            MesecnaRata = mesecnaRata;
        }
    }

    //SIGURNOSNA KONTROLA
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

    //KAMATA
    public class KamataPregled
    {
        public int Id { get; set; }
        public int PredmetObracunaId { get; set; }
        public string PredmetTip { get; set; }
        public string KonkretanPredmet { get; set; }
        public string TipKamate { get; set; }
        public double IznosKamate { get; set; }
        public string PeriodObracuna { get; set; }
        public DateTime DatumObracuna { get; set; }
        public string Status { get; set; }

        public KamataPregled() {}
    }

    public class KamataBasic
    {
        public int Id { get; set; }
        public int PredmetObracunaId { get; set; }
        public string TipKamate { get; set; }
        public double IznosKamate { get; set; }
        public string PeriodObracuna { get; set; }
        public DateTime DatumObracuna { get; set; }
        public string Status { get; set; }

        public KamataBasic() {}
    }

    public class PredmetObracunaOpcija
    {
        public int PredmetObracunaId { get; set; }
        public string Prikaz { get; set; }

        public PredmetObracunaOpcija() {}

        public PredmetObracunaOpcija(int predmetObracunaId, string prikaz)
        {
            PredmetObracunaId = predmetObracunaId;
            Prikaz = prikaz;
        }
    }
}
