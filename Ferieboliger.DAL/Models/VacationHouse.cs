using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class VacationHouse
    {
        [Key]
        public int Id { get; set; }

        public int FileInformationId { get; set; }
        public FileInformation FileInformation { get; set; }

        [Required]
        public string Address { get; set; }
        
        // TODO - Skal denne med, eller skal vi blot finde ud af det, baseret på datoer der er booket?
        public bool CurrentlyRented { get; set; }

        // TODO - Hvilke oplysninger skal vi have med på sommerhuset?
        public int TotalBedrooms { get; set; }
    }
}
