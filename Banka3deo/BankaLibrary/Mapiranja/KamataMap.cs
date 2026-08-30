using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    public class KamataMap : ClassMap<Kamata>
    {
        public KamataMap()
        {
            Table("KAMATA");

            Id(x => x.Id, "ID").GeneratedBy.Increment();

            Map(x => x.Status, "STATUS");
            Map(x => x.TipKamate, "TIP_KAMATE");
            Map(x => x.DatumObracuna, "DATUM_OBRACUNA");
            Map(x => x.PeriodObracuna, "PERIOD_OBRACUNA");
            Map(x => x.IznosKamate, "IZNOS_KAMATE");

            References(x => x.PredmetObracuna, "ID_PREDMETA_OBRACUNA");
        }
    }
}
