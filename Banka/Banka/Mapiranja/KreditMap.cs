using Banka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Mapiranja
{
    class KreditMap : ClassMap<Kredit>
    {
        public KreditMap()
        {
            Table("KREDIT");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.StatusKredita, "STATUS_KREDITA");
            Map(x => x.Namena, "NAMENA");
            Map(x => x.Komentar, "KOMENTAR");
            Map(x => x.Iznos, "IZNOS");
            Map(x => x.Valuta, "VALUTA");
            Map(x => x.KamatnaStopa, "KAMATNA_STOPA");
            Map(x => x.RokOtplate, "ROK_OTPLATE");
            Map(x => x.MesecnaRata, "MESECNA_RATA");
            Map(x => x.DatumDospeca, "DATUM_DOSPECA");
            Map(x => x.DatumOdobrenja, "DATUM_ODOBRENJA");

            References(x => x.Klijent, "ID_KLIJENTA");
            References(x => x.Racun, "ID_RACUNA");
            References(x => x.PredmetObracuna, "ID_PREDMETA_OBRACUNA");
        }
    }
}
