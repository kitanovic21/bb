using BankaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Mapiranja
{
    public class DozvoljeneValuteMap : ClassMap<DozvoljeneValute>
    {
        public DozvoljeneValuteMap()
        {
            Table("DOZVOLJENE_VALUTE");

            CompositeId()
                .KeyReference(x => x.Racun, "BROJ_RACUNA")     
                .KeyProperty(x => x.Valuta, "DOZVOLJENE_VALUTE");   
        }
    }
}
