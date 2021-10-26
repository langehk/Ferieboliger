using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class FileInformation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VacationHouseId { get; set; }
        public VacationHouse VacationHouse { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Data{ get; set; }
    }
}
