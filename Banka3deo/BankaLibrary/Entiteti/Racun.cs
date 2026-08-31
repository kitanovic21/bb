using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public abstract class Racun
    {
        public virtual string BrojRacuna { get; set; }

        public virtual string TipRacuna { get; set; }
        public virtual string StatusRacuna { get; set; }
        public virtual double? DozvoljeniMinus { get; set; }
        public virtual double TrenutnoStanje { get; set; }
        public virtual string Valuta { get; set; }
        public virtual string Komentar { get; set; }
        public virtual DateTime DatumOtvaranja { get; set; }
        public virtual double? KamatnaStopa { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual PredmetObracuna PredmetObracuna { get; set; }
        public virtual IList<DozvoljeneValute> DozvoljeneValute { get; set; } = new List<DozvoljeneValute>();
        public virtual IList<PovezaniPaketiUsluga> PovezaniPaketi { get; set; } = new List<PovezaniPaketiUsluga>();
        public Racun() 
        {
            DozvoljeneValute = new List<DozvoljeneValute>();
            PovezaniPaketi = new List<PovezaniPaketiUsluga>();
        }
    }
}
