using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class FizickoLice : Klijent
    {
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string BrojLicneKarte { get; set; }
        public virtual string JMBG { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public FizickoLice()
        {

        }
    }
}
