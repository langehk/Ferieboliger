using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferieboliger.ViewModel
{
    public class FiltreretFeriebolig
    {
        public HashSet<string> Byer { get; set; }

        public List<string> BoligType { get; set; }

        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
    }
}
