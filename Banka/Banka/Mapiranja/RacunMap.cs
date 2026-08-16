using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class RacunMap : ClassMap<Racun>
    {
        public RacunMap() 
        {
            Table("RACUN");

            Id(x => x.BrojRacuna, "BROJ_RACUNA").GeneratedBy.Assigned();//zato sto sami unosimo id

            Map(x => x.TipRacuna, "TIP_RACUNA");
            Map(x => x.StatusRacuna, "STATUS_RACUNA");
            Map(x => x.DozvoljeniMinus, "DOZVOLJENI_MINUS");
            Map(x => x.TrenutnoStanje, "TRENUTNO_STANJE");
            Map(x => x.Valuta, "VALUTA");
            Map(x => x.Komentar, "KOMENTAR");
            Map(x => x.DatumOtvaranja, "DATUM_OTVARANJA");
            Map(x => x.KamatnaStopa, "KAMATNA_STOPA");

            References(x => x.Klijent, "ID_KLIJENTA");
            References(x => x.PredmetObracuna, "ID_PREDMETA_OBRACUNA");

            HasMany(x => x.DozvoljeneValute)
                .KeyColumn("BROJ_RACUNA")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.PovezaniPaketi)
                .KeyColumn("BROJ_RACUNA")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
