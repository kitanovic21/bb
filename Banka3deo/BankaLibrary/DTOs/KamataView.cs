using System;
using BankaLibrary.Entiteti;

namespace BankaLibrary.DTOs
{
    public class KamataView
    {
        public int Id { get; set; }
        public string Status { get; set; } = "obracunata";
        public string TipKamate { get; set; } = string.Empty;
        public DateTime DatumObracuna { get; set; }
        public string? PeriodObracuna { get; set; }
        public double IznosKamate { get; set; }

        // --- FK ---
        public int PredmetObracunaID { get; set; }

        public KamataView() { }

        // Entitet -> DTO
        public KamataView(Kamata k)
        {
            if (k == null) return;

            Id = k.Id;
            Status = k.Status;
            TipKamate = k.TipKamate;
            DatumObracuna = k.DatumObracuna;
            PeriodObracuna = k.PeriodObracuna;
            IznosKamate = k.IznosKamate;

            PredmetObracunaID = k.PredmetObracuna?.ID ?? 0;
        }

        // DTO -> entitet. PredmetObracuna se ne postavlja ovde jer zahteva
        // učitavanje iz baze (session.GetAsync) - to radi DataProvider,
        // koristeći PredmetObracunaID iz ovog DTO-a.
        public Kamata ToEntity()
        {
            return new Kamata
            {
                Id = Id,
                Status = Status,
                TipKamate = TipKamate,
                DatumObracuna = DatumObracuna,
                PeriodObracuna = PeriodObracuna,
                IznosKamate = IznosKamate
            };
        }
    }
}
