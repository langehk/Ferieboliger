using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Bruger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Navn { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public int Point { get; set; }
    }
}
