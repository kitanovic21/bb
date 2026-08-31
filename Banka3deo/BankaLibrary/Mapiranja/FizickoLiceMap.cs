using BankaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Mapiranja
{
    class FizickoLiceMap : SubclassMap<FizickoLice>
    {
        public FizickoLiceMap() 
        {
            Table("FIZICKO_LICE");
            KeyColumn("ID");

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.BrojLicneKarte, "BROJ_LICNE_KARTE");
            Map(x => x.JMBG, "JMBG");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
        }
    }
}
