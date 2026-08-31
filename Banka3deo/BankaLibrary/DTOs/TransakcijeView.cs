using System;
using System.Collections.Generic;
using System.Text;

namespace BankaLibrary.DTOs
{
    public class TransakcijeView
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
        public string Referenca { get; set; }
        public string PodaciOPrimaocu { get; set; }
        public string Komentar { get; set; }
        public string Opis { get; set; }

        public TransakcijeView() { }

        public TransakcijeView(Transakcija t)
        {
            if (t != null)
            {
                KodTransakcije = t.KodTransakcije;
                BrojRacunaPosiljalac = t.Racun?.BrojRacuna;
                TipTransakcije = t.TipTransakcije;
                Iznos = t.Iznos;
                Valuta = t.Valuta;
                Status = t.Status;
                Datum = t.Datum;
                Vreme = t.Vreme;
                BrojRacunaPrimalac = t.NaKojiRacun?.BrojRacuna;
                Referenca = t.Referenca;
                PodaciOPrimaocu = t.PodaciOPrimaocu;
                Komentar = t.Komentar;
                Opis = t.Opis;
            }
        }
    }
}