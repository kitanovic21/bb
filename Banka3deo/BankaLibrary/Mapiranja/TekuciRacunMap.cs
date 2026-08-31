using BankaLibrary.Entiteti;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Mapiranja
{
    class TekuciRacunMap : SubclassMap<TekuciRacun>
    {
        public TekuciRacunMap() 
        {
            Table("TEKUCI_RACUN");
            KeyColumn("BROJ_RACUNA");

            Map(x => x.MogucnostPlatnihKartica,"MOGUCNOST_PLATNIH_KARTICA");
            Map(x => x.MesecniLimitTransakcija, "MESECNI_LIMIT_TRANSAKCIJA");
        }
    }
}
