using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Entiteti
{
    public abstract class Klijent
    {
        public virtual int ID { get; set; }
        public virtual string TipKlijenta { get; set; }
        public virtual string Status { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Grad { get; set; }
        public virtual string Email { get; set; }
        public virtual string Komentar { get; set; }
        public virtual IList<TelefonKlijenta> Telefoni { get; set; } = new List<TelefonKlijenta>();

        public Klijent()
        {

        }
    }
}
