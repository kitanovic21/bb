using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class ZiroRacun : Racun
    {
        public virtual string Namena { get; set; }
        public virtual string EBankarstvoZaFirme { get; set; }
        public virtual double? LimitMasovnihPlacanja { get; set; }
        public virtual string Integracija { get; set; }

        public ZiroRacun() { }
    }
}
