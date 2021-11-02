using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Filoplysning
    {
        [Key]
        public int Id { get; set; }

        public int FerieboligId { get; set; }

        public Feriebolig Feriebolig { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Data{ get; set; }
    }
}
