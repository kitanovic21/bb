using BankaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Mapiranja
{
    class DepozitMap : ClassMap<Depozit>
    {
        public DepozitMap()
        {
            Table("DEPOZIT");

            Id(x => x.Id, "ID").GeneratedBy.Identity();

            Map(x => x.Iznos, "IZNOS");
            Map(x => x.Komentar, "KOMENTAR");
            Map(x => x.PeriodOrocenja, "PERIOD_OROCENJA");
            Map(x => x.DatumPocetka, "DATUM_POCETKA");
            Map(x => x.Valuta, "VALUTA");
            Map(x => x.OcekivanaKamata, "OCEKIVANA_KAMATA");
            Map(x => x.DatumIsteka, "DATUM_ISTEKA");
            Map(x => x.Status, "STATUS");
            Map(x => x.KamatnaStopa, "KAMATNA_STOPA");

            References(x => x.Klijent, "ID_KLIJENTA");
            References(x => x.PredmetObracuna, "ID_PREDMETA_OBRACUNA");

            References(x => x.Racun, "ID_RACUNA");
        }
    }
}
