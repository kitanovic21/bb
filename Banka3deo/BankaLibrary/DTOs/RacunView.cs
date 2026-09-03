using System;
using System.Collections.Generic;
using System.Linq;
using BankaLibrary.Entiteti;

namespace BankaLibrary.DTOs
{
    public class RacunView
    {
        //Zajednička polja
        public string BrojRacuna { get; set; } = string.Empty; // obavezno - PK, dodeljuje se ručno
        public string TipRacuna { get; set; } = string.Empty;  // obavezno - diskriminator
        public string? StatusRacuna { get; set; }
        public double? DozvoljeniMinus { get; set; }
        public double TrenutnoStanje { get; set; }
        public string? Valuta { get; set; }
        public string? Komentar { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public double? KamatnaStopa { get; set; }

        public int KlijentID { get; set; }
        public int? PredmetObracunaID { get; set; }

        public List<string> DozvoljeneValuteList { get; set; } = new();
        public List<string> PovezaniPaketiList { get; set; } = new();

        // tekuci
        public string? MogucnostPlatnihKartica { get; set; }
        public int? MesecniLimitTransakcija { get; set; }

        // stedni
        public double? MinimalniIznosZaOtvaranje { get; set; }
        public string? UsloviPodizanjaSredstava { get; set; }
        public string? Frekvencija { get; set; }
        public double? BonusiZaDugorocnuStednju { get; set; }

        // devizni i ziro
        public string? Namena { get; set; }

        // devizni
        public string? OgranicenjaDeviznihPropisa { get; set; }
        public double? KursnaRazlikaKonverzije { get; set; }

        // ziro
        public string? EBankarstvoZaFirme { get; set; }
        public double? LimitMasovnihPlacanja { get; set; }
        public string? Integracija { get; set; }

        public RacunView() { }

        // Entitet -> DTO
        public RacunView(Racun r)
        {
            if (r == null) return;

            BrojRacuna = r.BrojRacuna;
            StatusRacuna = r.StatusRacuna;
            DozvoljeniMinus = r.DozvoljeniMinus;
            TrenutnoStanje = r.TrenutnoStanje;
            Valuta = r.Valuta;
            Komentar = r.Komentar;
            DatumOtvaranja = r.DatumOtvaranja;
            KamatnaStopa = r.KamatnaStopa;

            KlijentID = r.Klijent?.ID ?? 0;
            PredmetObracunaID = r.PredmetObracuna?.ID;

            DozvoljeneValuteList = r.DozvoljeneValute?.Select(dv => dv.Valuta).ToList() ?? new();
            PovezaniPaketiList = r.PovezaniPaketi?.Select(pp => pp.PovezaniPaket).ToList() ?? new();

            switch (r)
            {
                case TekuciRacun tr:
                    TipRacuna = "tekuci";
                    MogucnostPlatnihKartica = tr.MogucnostPlatnihKartica;
                    MesecniLimitTransakcija = tr.MesecniLimitTransakcija;
                    break;

                case StedniRacun sr:
                    TipRacuna = "stedni";
                    MinimalniIznosZaOtvaranje = sr.MinimalniIznosZaOtvaranje;
                    UsloviPodizanjaSredstava = sr.UsloviPodizanjaSredstava;
                    Frekvencija = sr.Frekvencija;
                    BonusiZaDugorocnuStednju = sr.BonusiZaDugorocnuStednju;
                    break;

                case DevizniRacun dr:
                    TipRacuna = "devizni";
                    Namena = dr.Namena;
                    OgranicenjaDeviznihPropisa = dr.OgranicenjaDeviznihPropisa;
                    KursnaRazlikaKonverzije = dr.KursnaRazlikaKonverzije;
                    break;

                case ZiroRacun zr:
                    TipRacuna = "ziro";
                    Namena = zr.Namena;
                    EBankarstvoZaFirme = zr.EBankarstvoZaFirme;
                    LimitMasovnihPlacanja = zr.LimitMasovnihPlacanja;
                    Integracija = zr.Integracija;
                    break;

                default:
                    TipRacuna = r.TipRacuna ?? r.GetType().Name;
                    break;
            }
        }

        // DTO -> entitet. Klijent i PredmetObracuna se ne postavljaju ovde jer
        // zahtevaju učitavanje iz baze (session.GetAsync) - to radi DataProvider,
        // koristeći KlijentID / PredmetObracunaID iz ovog DTO-a.
        public Racun ToEntity()
        {
            Racun racun;

            switch (TipRacuna)
            {
                case "tekuci":
                    racun = new TekuciRacun
                    {
                        MogucnostPlatnihKartica = MogucnostPlatnihKartica,
                        MesecniLimitTransakcija = MesecniLimitTransakcija
                    };
                    break;

                case "stedni":
                    racun = new StedniRacun
                    {
                        MinimalniIznosZaOtvaranje = MinimalniIznosZaOtvaranje ?? 0,
                        UsloviPodizanjaSredstava = UsloviPodizanjaSredstava,
                        Frekvencija = Frekvencija,
                        BonusiZaDugorocnuStednju = BonusiZaDugorocnuStednju
                    };
                    break;

                case "devizni":
                    racun = new DevizniRacun
                    {
                        Namena = Namena,
                        OgranicenjaDeviznihPropisa = OgranicenjaDeviznihPropisa,
                        KursnaRazlikaKonverzije = KursnaRazlikaKonverzije
                    };
                    break;

                case "ziro":
                    racun = new ZiroRacun
                    {
                        Namena = Namena,
                        EBankarstvoZaFirme = EBankarstvoZaFirme,
                        LimitMasovnihPlacanja = LimitMasovnihPlacanja,
                        Integracija = Integracija
                    };
                    break;

                default:
                    throw new ArgumentException($"Nepoznat TipRacuna: '{TipRacuna}'. Očekivano 'tekuci', 'stedni', 'tekuci' ili 'ziro'.");
            }

            racun.BrojRacuna = BrojRacuna;
            racun.TipRacuna = TipRacuna;
            racun.StatusRacuna = StatusRacuna;
            racun.DozvoljeniMinus = DozvoljeniMinus;
            racun.TrenutnoStanje = TrenutnoStanje;
            racun.Valuta = Valuta;
            racun.Komentar = Komentar;
            racun.DatumOtvaranja = DatumOtvaranja;
            racun.KamatnaStopa = KamatnaStopa;

            return racun;
        }
    }
}