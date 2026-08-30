using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class PredmetObracunaMap : ClassMap<PredmetObracuna>
    {
        public PredmetObracunaMap() 
        {
            Table("PREDMET_OBRACUNA");

            Id(x => x.ID, "ID").GeneratedBy.Increment();

            HasMany(x => x.Kamate)
                .KeyColumn("ID_PREDMETA_OBRACUNA")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
