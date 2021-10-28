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
    public class Feriebolig
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Facilitet> Faciliteter { get; set; }
        public ICollection<Booking> Bookinger { get; set; }
        public ICollection<Filoplysning> Filer { get; set; }

        [Required]
        [ForeignKey("Id")]
        public Adresse Adresse { get; set; }

        [Required]
        public int NoeglerTilgaengelig { get; set; }

        [Required]
        public int PrisLav { get; set; }

        [Required]
        public int PrisHoej { get; set; }
       
        public TimeSpan? AnkomstTidspunkt { get; set; }

        public TimeSpan? AfgangTidspunkt { get; set; }
        
        public int BeskatningLav { get; set; }
        public int BeskatningHoej { get; set; }

        [DefaultValue(FerieboligType.Feriebolig)]
        public FerieboligType Type { get; set; }

        [Required]
        public bool SendNoegler { get; set; }
        public int AntalSovepladser { get; set; }
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

        [DefaultValue(FerieboligStatus.Ledigt)]
        public FerieboligStatus Status { get; set; }

    }
}
