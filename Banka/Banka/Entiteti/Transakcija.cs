using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Entiteti
{
    public class Transakcija
    {
        public virtual int KodTransakcije { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual string TipTransakcije { get; set; }
        public virtual string Referenca { get; set; }
        public virtual double Iznos { get; set; }
        public virtual string PodaciOPrimaocu { get; set; }
        public virtual string Komentar { get; set; }
        public virtual string Valuta { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? Datum { get; set; }
        public virtual string Vreme { get; set; }
        public virtual Racun NaKojiRacun { get; set; }

        public Transakcija() { }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(Transakcija))
                return false;

            Transakcija recievedObject = (Transakcija)obj;

            if (this.Racun == null || recievedObject.Racun == null)
                return false;

            return (this.KodTransakcije == recievedObject.KodTransakcije) &&
                   (this.Racun.BrojRacuna == recievedObject.Racun.BrojRacuna);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
