using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferieboliger.DAL.Models.Enums;

namespace Ferieboliger.DAL.Models
{
    public class RedigerbarSide
    {
        [Key]
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public RedigerbarSideType Type { get; set; }
    }
}
