using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Banka.Entiteti;

namespace Banka.Mapiranja
{
    class KlijentMap : ClassMap<Klijent>
    {
        public KlijentMap() 
        {
            Table("KLIJENT");

            Id(x => x.ID, "ID").GeneratedBy.Increment();

            Map(x => x.TipKlijenta, "TIP_KLIJENTA");
            Map(x => x.Status, "STATUS");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Grad, "GRAD");
            Map(x => x.Email, "EMAIL");
            Map(x => x.Komentar, "KOMENTAR");

            HasMany(x => x.Telefoni)
                .KeyColumn("ID_KLIJENTA")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.Racuni)
                .KeyColumn("ID_KLIJENTA") //BROJ_RACUNA
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
