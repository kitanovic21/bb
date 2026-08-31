using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class Kredit
    {
        public virtual int Id { get; set; }
        public virtual string StatusKredita { get; set; }
        public virtual string Namena { get; set; }
        public virtual string Komentar { get; set; }
        public virtual double Iznos { get; set; }
        public virtual string Valuta { get; set; }
        public virtual double? KamatnaStopa { get; set; }
        public virtual int? RokOtplate { get; set; }
        public virtual double? MesecnaRata { get; set; }
        public virtual DateTime? DatumDospeca { get; set; }
        public virtual DateTime DatumOdobrenja { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual PredmetObracuna PredmetObracuna { get; set; }

        public Kredit() 
        {

        }
    }
}
