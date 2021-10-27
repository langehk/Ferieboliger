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

        [ForeignKey("Id")]
        public Bruger Bruger { get; set; }

        [ForeignKey("Id")]
        public Feriebolig Feriebolig { get; set; }

        [Required]
        public DateTime UdlejDato { get; set; }

        [Required]
        public DateTime AfrejseDato { get; set; }

        [Required]
        public bool NoeglerReturneret { get; set; }

        [Required]
        public bool NoeglerSendt { get; set; }

        [Required]
        public int Pris { get; set; }

        public string Kommentarer { get; set; }

        //[DefaultValue(BookingStatus.Ledigt)]
        [Required]
        public BookingStatus Status { get; set; }

        [Required]
        public BookingPointPris PointPris { get; set; }

        public int Beskatning { get; set; }
    }
}
