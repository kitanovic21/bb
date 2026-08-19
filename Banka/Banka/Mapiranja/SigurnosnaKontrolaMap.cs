using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class SigurnosnaKontrolaMap : ClassMap<SigurnosnaKontrola>
    {
        public SigurnosnaKontrolaMap()
        {
            Table("SIGURNOSNA_KONTROLA");

            Id(x => x.Id, "ID").GeneratedBy.Identity();

            Map(x => x.TipDogadjaja, "TIP_DOGADJAJA");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Status, "STATUS");
            Map(x => x.IpAdresa, "IP_ADRESA");
            Map(x => x.PodaciOUredjaju, "PODACI_O_UREDJAJU");
            Map(x => x.Datum, "DATUM");
            Map(x => x.Vreme, "VREME");

            References(x => x.Klijent, "ID_KLIJENTA").Nullable();
            References(x => x.Racun, "ID_RACUNA").Nullable();
        }
    }
}
