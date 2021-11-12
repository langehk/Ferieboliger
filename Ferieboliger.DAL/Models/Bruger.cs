using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Det skal være en gyldig emailadresse")]
        public string Email { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required]
        public int Point { get; set; }

        public ICollection<Booking> Bookinger { get; set; }
    }
}
