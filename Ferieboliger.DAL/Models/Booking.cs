using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int VacationHouseId { get; set; }

        public VacationHouse VacationHouse { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public bool ReturnedKeys { get; set; }

        [Required]
        public int Price { get; set; }

        public string Comments { get; set; }
    }
}
