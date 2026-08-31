using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class Kamata
    {
        public virtual int Id { get; set; }
        public virtual string Status { get; set; }
        public virtual string TipKamate { get; set; }
        public virtual DateTime DatumObracuna { get; set; }
        public virtual string PeriodObracuna { get; set; }
        public virtual double IznosKamate { get; set; }

        public virtual PredmetObracuna PredmetObracuna { get; set; }

        public Kamata() { }
    }
}
