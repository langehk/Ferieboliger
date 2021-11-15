using Ferieboliger.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferieboliger.ViewModel
{
    public class FiltreretFeriebolig
    {
        public HashSet<string> Byer { get; set; }

        public HashSet<FerieboligType> BoligType { get; set; }

        public DateTime? StartDato { get; set; }
        public DateTime? SlutDato { get; set; }
    }
}
