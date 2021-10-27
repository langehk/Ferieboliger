using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Facilitet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Beskrivelse { get; set; }

        public ICollection<Feriebolig> Ferieboliger { get; set; }
    }
}
