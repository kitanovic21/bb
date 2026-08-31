using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class TelefonKlijenta
    {
        public virtual Klijent Klijent { get; set; }
        public virtual string BrojTelefona { get; set; }
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(TelefonKlijenta))
                return false;

            TelefonKlijenta recievedObject = (TelefonKlijenta)obj;

            if (this.Klijent == null || recievedObject.Klijent == null)
                return false;

            if ((this.Klijent.ID == recievedObject.Klijent.ID) &&
                (this.BrojTelefona == recievedObject.BrojTelefona))
            {
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public TelefonKlijenta() { }
    }
}
