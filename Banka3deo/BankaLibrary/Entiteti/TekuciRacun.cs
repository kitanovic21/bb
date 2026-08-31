using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class TekuciRacun : Racun
    {
        public virtual string MogucnostPlatnihKartica { get; set; }
        public virtual int? MesecniLimitTransakcija { get; set; }

        public TekuciRacun()
        {

        }
    }
}
