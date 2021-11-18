using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Spaerring
    {
        public int Id { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public string Beskrivelse { get; set; }
        public int FerieboligId { get; set; }
        public Feriebolig Feriebolig { get; set; }
    }
}
