using System;
using BankaLibrary.Entiteti;

namespace BankaLibrary.DTOs
{
    public class SigurnosnaKontrolaView
    {
        public int Id { get; set; }
        public string TipDogadjaja { get; set; } = string.Empty;
        public string? Opis { get; set; }
        public string Status { get; set; } = "uspesno";
        public string? IpAdresa { get; set; }
        public string? PodaciOUredjaju { get; set; }
        public DateTime Datum { get; set; }
        public string? Vreme { get; set; }

        // --- FK-jevi (oba opciona - događaj ne mora biti vezan ni za klijenta ni za račun) ---
        public int? KlijentID { get; set; }
        public string? BrojRacuna { get; set; }

        public SigurnosnaKontrolaView() { }

        // Entitet -> DTO
        public SigurnosnaKontrolaView(SigurnosnaKontrola sk)
        {
            if (sk == null) return;

            Id = sk.Id;
            TipDogadjaja = sk.TipDogadjaja;
            Opis = sk.Opis;
            Status = sk.Status;
            IpAdresa = sk.IpAdresa;
            PodaciOUredjaju = sk.PodaciOUredjaju;
            Datum = sk.Datum;
            Vreme = sk.Vreme;

            KlijentID = sk.Klijent?.ID;
            BrojRacuna = sk.Racun?.BrojRacuna;
        }

        // DTO -> entitet. Klijent i Racun se ne postavljaju ovde jer zahtevaju
        // učitavanje iz baze (session.GetAsync) - to radi DataProvider,
        // koristeći KlijentID / BrojRacuna iz ovog DTO-a.
        public SigurnosnaKontrola ToEntity()
        {
            return new SigurnosnaKontrola
            {
                Id = Id,
                TipDogadjaja = TipDogadjaja,
                Opis = Opis,
                Status = Status,
                IpAdresa = IpAdresa,
                PodaciOUredjaju = PodaciOUredjaju,
                Datum = Datum,
                Vreme = Vreme
            };
        }
    }
}
