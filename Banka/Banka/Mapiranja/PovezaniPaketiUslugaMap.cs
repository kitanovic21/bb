using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    public class PovezaniPaketiUslugaMap : ClassMap<PovezaniPaketiUsluga>
    {
        public PovezaniPaketiUslugaMap()
        {
            Table("POVEZANI_PAKETI_USLUGA");

            CompositeId()
                .KeyReference(x => x.Racun, "BROJ_RACUNA")            // Strani ključ ka tabeli RACUN
                .KeyProperty(x => x.PovezaniPaket, "POVEZANI_PAKET"); // Kolona sa nazivom paketa
        }
    }
}
