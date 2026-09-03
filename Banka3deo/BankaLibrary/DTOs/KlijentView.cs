using System;
using System.Collections.Generic;
using System.Linq;
using BankaLibrary.Entiteti;

namespace BankaLibrary.DTOs
{
    // Flat DTO za apstraktnu klasu Klijent.
    // TipKlijenta je diskriminator ("FizickoLice" ili "PravnoLice") i govori
    // koja grupa polja ispod treba da bude popunjena.
    public class KlijentView
    {
        // --- Zajednička polja (iz Klijent) ---
        public int ID { get; set; }
        public string TipKlijenta { get; set; } = string.Empty; // "FizickoLice" | "PravnoLice" - jedino ovo je stvarno obavezno
        public string? Status { get; set; }
        public string? Adresa { get; set; }
        public string? Grad { get; set; }
        public string? Email { get; set; }
        public string? Komentar { get; set; }

        public List<string> Telefoni { get; set; } = new();
        public List<string> BrojeviRacuna { get; set; } = new();

        // --- Polja samo za FizickoLice (null kad je TipKlijenta == "PravnoLice") ---
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? BrojLicneKarte { get; set; }
        public string? JMBG { get; set; }
        public DateTime? DatumRodjenja { get; set; }

        // --- Polja samo za PravnoLice (null kad je TipKlijenta == "FizickoLice") ---
        public string? NazivFirme { get; set; }
        public string? PIB { get; set; }

        public KlijentView() { }

        // Entitet -> DTO
        public KlijentView(Klijent k)
        {
            if (k == null) return;

            ID = k.ID;
            Status = k.Status;
            Adresa = k.Adresa;
            Grad = k.Grad;
            Email = k.Email;
            Komentar = k.Komentar;

            Telefoni = k.Telefoni?.Select(t => t.BrojTelefona).ToList() ?? new();
            BrojeviRacuna = k.Racuni?.Select(r => r.BrojRacuna).ToList() ?? new();

            switch (k)
            {
                case FizickoLice fl:
                    TipKlijenta = "fizicko";
                    Ime = fl.Ime;
                    Prezime = fl.Prezime;
                    BrojLicneKarte = fl.BrojLicneKarte;
                    JMBG = fl.JMBG;
                    DatumRodjenja = fl.DatumRodjenja;
                    break;

                case PravnoLice pl:
                    TipKlijenta = "pravno";
                    NazivFirme = pl.NazivFirme;
                    PIB = pl.PIB;
                    break;

                default:
                    // fallback - ne bi trebalo da se desi, ali ne rušimo mapiranje
                    TipKlijenta = k.TipKlijenta ?? k.GetType().Name;
                    break;
            }
        }

        // DTO -> entitet (za dodavanje/izmenu preko DataProvider-a).
        // Klijent ID/Racuni/Telefoni se po pravilu ne postavljaju ovde direktno
        // nego u DataProvider-u nakon što se učita/poveže sa bazom, ako je potrebno.
        public Klijent ToEntity()
        {
            Klijent klijent;

            switch (TipKlijenta)
            {
                case "fizicko":
                    klijent = new FizickoLice
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        BrojLicneKarte = BrojLicneKarte,
                        JMBG = JMBG,
                        DatumRodjenja = DatumRodjenja ?? default
                    };
                    break;

                case "pravno":
                    klijent = new PravnoLice
                    {
                        NazivFirme = NazivFirme,
                        PIB = PIB
                    };
                    break;

                default:
                    throw new ArgumentException($"Nepoznat TipKlijenta: '{TipKlijenta}'. Očekivano 'fizicko' ili 'pravno'.");
            }

            klijent.ID = ID;
            klijent.TipKlijenta = TipKlijenta;
            klijent.Status = Status;
            klijent.Adresa = Adresa;
            klijent.Grad = Grad;
            klijent.Email = Email;
            klijent.Komentar = Komentar;

            return klijent;
        }
    }
}