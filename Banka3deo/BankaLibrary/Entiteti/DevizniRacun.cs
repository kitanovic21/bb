using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class DevizniRacun : Racun
    {
        public virtual string Namena { get; set; }
        public virtual string OgranicenjaDeviznihPropisa { get; set; }
        public virtual double? KursnaRazlikaKonverzije { get; set; }
        public DevizniRacun() { }
    }
}
