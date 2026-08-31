using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
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
        public virtual IList<Racun> Racuni { get; set; } = new List<Racun>();


        public Klijent()
        {
            Telefoni = new List<TelefonKlijenta>();
            Racuni = new List<Racun>();

        }
    }
}
