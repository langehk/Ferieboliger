using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Adresse
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        public string Vej { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        [DataType(DataType.PostalCode)]
        public string Postnummer { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "Må kun indeholde bogstaver")]
        public string By { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        public string Land { get; set; }

        public int FerieboligId { get; set; }
        public Feriebolig Feriebolig { get; set; }
    }
}
