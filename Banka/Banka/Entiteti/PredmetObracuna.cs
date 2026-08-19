using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Entiteti
{
    public class PredmetObracuna
    {
        public virtual int ID { get; set; }
        public virtual IList<Kamata> Kamate { get; set; } = new List<Kamata>();

        public PredmetObracuna() { }
    }
}
