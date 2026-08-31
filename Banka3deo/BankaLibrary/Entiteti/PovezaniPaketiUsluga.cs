using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class PovezaniPaketiUsluga
    {
        public virtual Racun Racun { get; set; }
        public virtual string PovezaniPaket { get; set; }

        public PovezaniPaketiUsluga() { }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(PovezaniPaketiUsluga))
                return false;

            PovezaniPaketiUsluga recievedObject = (PovezaniPaketiUsluga)obj;

            if (this.Racun == null || recievedObject.Racun == null)
                return false;

            return (this.Racun.BrojRacuna == recievedObject.Racun.BrojRacuna) &&
                   (this.PovezaniPaket == recievedObject.PovezaniPaket);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
