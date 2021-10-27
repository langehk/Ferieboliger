using Ferieboliger.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class Feriebolig
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Facilitet> Faciliteter { get; set; }
        public ICollection<Booking> Bookinger { get; set; }
        public ICollection<Filoplysning> Filer { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public bool Udlejet { get; set; }

        [Required]
        public bool NoeglerTilgaengelig { get; set; }

        [Required]
        public int PrisLav { get; set; }

        [Required]
        public int PrisHoej { get; set; }

        [Required]
        public DateTime AnkomstTidspunkt { get; set; }

        [Required]
        public DateTime AfgangTidspunkt { get; set; }

        
        public int BeskatningLav { get; set; }
        public int BeskatningHoej { get; set; }

        [Required]
        public FerieboligType Type { get; set; }

        [Required]
        public bool SendNoegler { get; set; }
        public int AntalSoveplader { get; set; }
        public int AntalBadevaerelser { get; set; }
        public int AntalPersoner { get; set; }
        public int AntalHusdyr { get; set; }
        public bool HusdyrTilladt { get; set; }
        public int AntalKvadratmeter { get; set; }
        public int Grundareal { get; set; }
        public int AfstandStrand { get; set; }
        public int AfstandRestaurant { get; set; }
        public int AfstandIndkoeb { get; set; }
        public string Bemaerkninger { get; set; }
        public string Beskrivelse { get; set; }

    }
}
