using System;
using BankaLibrary.Entiteti;

namespace BankaLibrary.DTOs
{
    public class KreditView
    {
        public int Id { get; set; }
        public string StatusKredita { get; set; } = string.Empty;
        public string? Namena { get; set; }
        public string? Komentar { get; set; }
        public double Iznos { get; set; }
        public string Valuta { get; set; } = "RSD";
        public double? KamatnaStopa { get; set; }
        public int? RokOtplate { get; set; }
        public double? MesecnaRata { get; set; }
        public DateTime? DatumDospeca { get; set; }
        public DateTime DatumOdobrenja { get; set; }

        // --- FK-jevi ---
        public int KlijentID { get; set; }
        public string BrojRacuna { get; set; } = string.Empty;
        public int PredmetObracunaID { get; set; }

        public KreditView() { }

        // Entitet -> DTO
        public KreditView(Kredit k)
        {
            if (k == null) return;

            Id = k.Id;
            StatusKredita = k.StatusKredita;
            Namena = k.Namena;
            Komentar = k.Komentar;
            Iznos = k.Iznos;
            Valuta = k.Valuta;
            KamatnaStopa = k.KamatnaStopa;
            RokOtplate = k.RokOtplate;
            MesecnaRata = k.MesecnaRata;
            DatumDospeca = k.DatumDospeca;
            DatumOdobrenja = k.DatumOdobrenja;

            KlijentID = k.Klijent?.ID ?? 0;
            BrojRacuna = k.Racun?.BrojRacuna ?? string.Empty;
            PredmetObracunaID = k.PredmetObracuna?.ID ?? 0;
        }

        // DTO -> entitet. Klijent, Racun i PredmetObracuna se ne postavljaju ovde jer
        // zahtevaju učitavanje iz baze (session.GetAsync) - to radi DataProvider,
        // koristeći KlijentID / BrojRacuna / PredmetObracunaID iz ovog DTO-a.
        public Kredit ToEntity()
        {
            return new Kredit
            {
                Id = Id,
                StatusKredita = StatusKredita,
                Namena = Namena,
                Komentar = Komentar,
                Iznos = Iznos,
                Valuta = Valuta,
                KamatnaStopa = KamatnaStopa,
                RokOtplate = RokOtplate,
                MesecnaRata = MesecnaRata,
                DatumDospeca = DatumDospeca,
                DatumOdobrenja = DatumOdobrenja
            };
        }
    }
}
