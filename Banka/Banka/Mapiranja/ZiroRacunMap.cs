using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class ZiroRacunMap : SubclassMap<ZiroRacun>
    {
        ZiroRacunMap()
        {
            Table("DEVIZNI_RACUN");
            KeyColumn("BROJ_RACUNA");

            Map(x => x.Namena, "NAMENA");
            Map(x => x.EBankarstvoZaFirme, "E_BANKARSTVO_ZA_FIRME");
            Map(x => x.LimitMasovnihPlacanja, "LIMIT_MASOVNIH_PLACANJA");
            Map(x => x.Integracija, "INTEGRACIJA");


        }
    }
}
