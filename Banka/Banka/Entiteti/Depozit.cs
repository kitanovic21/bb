using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Entiteti
{
    public class Depozit
    {
        public virtual int Id { get; set; }
        public virtual double Iznos { get; set; }
        public virtual string Komentar { get; set; }
        public virtual int? PeriodOrocenja { get; set; }
        public virtual DateTime DatumPocetka { get; set; }
        public virtual string Valuta { get; set; }
        public virtual double? OcekivanaKamata { get; set; }
        public virtual DateTime? DatumIsteka { get; set; }
        public virtual string Status { get; set; }
        public virtual double? KamatnaStopa { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual Racun Racun { get; set; } // Opciono (može biti null)
        public virtual PredmetObracuna PredmetObracuna { get; set; }

        public Depozit() { }
    }
}
