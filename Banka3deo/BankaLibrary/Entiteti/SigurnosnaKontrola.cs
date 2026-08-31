using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class SigurnosnaKontrola
    {
        public virtual int Id { get; set; }
        public virtual string TipDogadjaja { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Status { get; set; }
        public virtual string IpAdresa { get; set; }
        public virtual string PodaciOUredjaju { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string Vreme { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual Racun Racun { get; set; }

        public SigurnosnaKontrola() { }
    }
}
