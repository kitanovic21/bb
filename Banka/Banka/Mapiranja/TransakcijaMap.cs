using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class TransakcijaMap : ClassMap<Transakcija>
    {
        public TransakcijaMap()
        {
            Table("TRANSAKCIJA");

            // Kompozitni primarni ključ
            CompositeId()
                .KeyProperty(x => x.KodTransakcije, "KOD_TRANSAKCIJE")
                .KeyReference(x => x.Racun, "BROJ_RACUNA");

            // Standardna polja
            Map(x => x.TipTransakcije, "TIP_TRANSAKCIJE");
            Map(x => x.Referenca, "REFERENCA");
            Map(x => x.Iznos, "IZNOS");
            Map(x => x.PodaciOPrimaocu, "PODACI_O_PRIMAOCU");
            Map(x => x.Komentar, "KOMENTAR");
            Map(x => x.Valuta, "VALUTA");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Status, "STATUS");
            Map(x => x.Datum, "DATUM");
            Map(x => x.Vreme, "VREME");

            // Drugi strani ključ ka tabeli RACUN (ID_NA_KOJI_RACUN) - može biti NULL
            References(x => x.NaKojiRacun, "ID_NA_KOJI_RACUN").Nullable();
        }
    }
}
