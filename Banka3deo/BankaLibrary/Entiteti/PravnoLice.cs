using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class PravnoLice : Klijent
    {
        public virtual string NazivFirme { get; set; }
        public virtual string PIB { get; set; }
        public PravnoLice()
        {

        }
    }
}
