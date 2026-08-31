using BankaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Mapiranja
{
    class StedniRacunMap : SubclassMap<StedniRacun>
    {
        public StedniRacunMap() 
        {
            Table("STEDNI_RACUN");
            KeyColumn("BROJ_RACUNA");

            Map(x => x.MinimalniIznosZaOtvaranje, "MINIMALNI_IZNOS_ZA_OTVARANJE");
            Map(x => x.UsloviPodizanjaSredstava, "USLOVI_PODIZANJA_SREDSTAVA");
            Map(x => x.Frekvencija, "FREKVENCIJA");
            Map(x => x.BonusiZaDugorocnuStednju, "BONUSI_ZA_DUGOROCNU_STEDNJU");

        }
    }
}
