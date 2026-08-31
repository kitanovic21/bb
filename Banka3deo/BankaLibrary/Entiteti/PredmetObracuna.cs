using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaLibrary.Entiteti
{
    public class PredmetObracuna
    {
        public virtual int ID { get; set; }
        public virtual IList<Kamata> Kamate { get; set; } = new List<Kamata>();

        public PredmetObracuna() 
        {
            Kamate = new List<Kamata>();
        }
    }
}
