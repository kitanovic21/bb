using BankaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Mapiranja
{
    class TelefonKlijentMap : ClassMap<TelefonKlijenta>
    {
        public TelefonKlijentMap() 
        {
            Table("TELEFON_KLIJENTA");
            CompositeId()
                .KeyReference(x => x.Klijent, "ID_KLIJENTA")
                .KeyProperty(x => x.BrojTelefona, "BROJ_TELEFONA");

        }
    }
}
