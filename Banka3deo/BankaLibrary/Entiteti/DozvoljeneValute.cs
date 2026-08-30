using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Entiteti
{
    public class DozvoljeneValute
    {
        public virtual Racun Racun { get; set; }
        public virtual string Valuta { get; set; }

        public DozvoljeneValute() { }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(DozvoljeneValute))
                return false;

            DozvoljeneValute recievedObject = (DozvoljeneValute)obj;

            if (this.Racun == null || recievedObject.Racun == null)
                return false;

            return (this.Racun.BrojRacuna == recievedObject.Racun.BrojRacuna) &&
                   (this.Valuta == recievedObject.Valuta);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
