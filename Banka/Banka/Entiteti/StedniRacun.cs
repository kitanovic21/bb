using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Entiteti
{
    public class StedniRacun : Racun
    {
        public virtual double MinimalniIznosZaOtvaranje { get; set; }
        public virtual string UsloviPodizanjaSredstava { get; set; }
        public virtual string Frekvencija { get; set; }
        public virtual double? BonusiZaDugorocnuStednju { get; set; }
        public StedniRacun() { }
    }
}
