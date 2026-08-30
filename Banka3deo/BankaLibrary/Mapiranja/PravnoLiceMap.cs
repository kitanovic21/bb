using Banka.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class PravnoLiceMap : SubclassMap<PravnoLice>
    {
        public PravnoLiceMap() 
        {
            Table("PRAVNO_LICE");
            KeyColumn("ID");

            Map(x => x.NazivFirme, "NAZIV_FIRME");
            Map(x => x.PIB, "PIB");
        }
    }
}
