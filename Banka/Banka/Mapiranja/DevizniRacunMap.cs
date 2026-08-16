using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class DevizniRacunMap : SubclassMap<DevizniRacun>
    {
        DevizniRacunMap() 
        {
            Table("DEVIZNI_RACUN");
            KeyColumn("BROJ_RACUNA");

            Map(x => x.Namena, "NAMENA");
            Map(x => x.OgranicenjaDeviznihPropisa, "OGRANICENJA_DEVIZNIH_PROPISA");
            Map(x => x.KursnaRazlikaKonverzije, "KURSNA_RAZLIKA_KONVERZIJE");

        }
    }
}
