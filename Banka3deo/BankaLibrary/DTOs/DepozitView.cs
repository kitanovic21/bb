using System;
using BankaLibrary.Entiteti;

namespace BankaLibrary.DTOs
{
    public class DepozitView
    {
        public int Id { get; set; }
        public double Iznos { get; set; }
        public string? Komentar { get; set; }
        public int? PeriodOrocenja { get; set; }
        public DateTime DatumPocetka { get; set; }
        public string Valuta { get; set; } = "RSD";
        public double? OcekivanaKamata { get; set; }
        public DateTime? DatumIsteka { get; set; }
        public string Status { get; set; } = "aktivan";
        public double? KamatnaStopa { get; set; }

        // --- FK-jevi ---
        public int KlijentID { get; set; }
        public string? BrojRacuna { get; set; } // opciono - depozit ne mora biti vezan za račun
        public int PredmetObracunaID { get; set; }

        public DepozitView() { }

        // Entitet -> DTO
        public DepozitView(Depozit d)
        {
            if (d == null) return;

            Id = d.Id;
            Iznos = d.Iznos;
            Komentar = d.Komentar;
            PeriodOrocenja = d.PeriodOrocenja;
            DatumPocetka = d.DatumPocetka;
            Valuta = d.Valuta;
            OcekivanaKamata = d.OcekivanaKamata;
            DatumIsteka = d.DatumIsteka;
            Status = d.Status;
            KamatnaStopa = d.KamatnaStopa;

            KlijentID = d.Klijent?.ID ?? 0;
            BrojRacuna = d.Racun?.BrojRacuna;
            PredmetObracunaID = d.PredmetObracuna?.ID ?? 0;
        }

        // DTO -> entitet. Klijent, Racun i PredmetObracuna se ne postavljaju ovde jer
        // zahtevaju učitavanje iz baze (session.GetAsync) - to radi DataProvider,
        // koristeći KlijentID / BrojRacuna / PredmetObracunaID iz ovog DTO-a.
        public Depozit ToEntity()
        {
            return new Depozit
            {
                Id = Id,
                Iznos = Iznos,
                Komentar = Komentar,
                PeriodOrocenja = PeriodOrocenja,
                DatumPocetka = DatumPocetka,
                Valuta = Valuta,
                OcekivanaKamata = OcekivanaKamata,
                DatumIsteka = DatumIsteka,
                Status = Status,
                KamatnaStopa = KamatnaStopa
            };
        }
    }
}
