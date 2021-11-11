using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Leveringsadresse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        public string Vej { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        [DataType(DataType.PostalCode)]
        public string Postnummer { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Må kun indeholde bogstaver")]
        public string By { get; set; }

        [Required(ErrorMessage = "Påkrævet felt")]
        public string Land { get; set; }

        public bool Firmaadresse { get; set; }

        public string Afdeling { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }
    }
}
