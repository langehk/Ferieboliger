using Ferieboliger.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Booking
    {

        [Key]
        public int Id { get; set; }

        public int BrugerId { get; set; }
        public Bruger Bruger { get; set; }

        public string PensionistNavn { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Det skal være en gyldig emailadresse")]
        public string PensionistEmail { get; set; }
        public string PensionistTelefon { get; set; }

        public int FerieboligId { get; set; }
        public Feriebolig Feriebolig { get; set; }

        [Required]
        public DateTime StartDato { get; set; }

        [Required]
        public DateTime SlutDato { get; set; }

        [Required]
        public bool NoeglerReturneret { get; set; } = false;

        [Required]
        public bool NoeglerSendt { get; set; } = false;

        [Required]
        public int Pris { get; set; }

        public string Kommentarer { get; set; }

        [Required]
        public BookingPointPris PointPris { get; set; }

        public int Beskatning { get; set; }

        [ValidateComplexType]
        public Leveringsadresse Leveringsadresse { get; set; } = new();

        public bool? Godkendt { get; set; } = true;

        public BookingPrioritet? Prioritet { get; set; }
    }
}
