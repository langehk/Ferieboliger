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
        public Feriebolig()
        {
            this.Faciliteter = new List<Facilitet>();
            this.Adresse = new Adresse();
            this.Bookinger = new List<Booking>();
            this.Spaerringer = new List<Spaerring>();
        }

        [Key]
        public int Id { get; set; }

        public ICollection<Facilitet> Faciliteter { get; set; }
        public ICollection<Booking> Bookinger { get; set; }
        public ICollection<Spaerring> Spaerringer { get; set; }
        public ICollection<Filoplysning> Filer { get; set; }

        [Required]
        public Adresse Adresse { get; set; }

        [Required]
        public int NoeglerTilgaengelig { get; set; }

        [Required]
        public int PrisLavUge { get; set; }

        [Required]
        public int PrisHoejUge { get; set; }

        public int PrisLavWeekend { get; set; }
        public int PrisHoejWeekend { get; set; }

        public TimeSpan? AnkomstTidspunkt { get; set; }

        public TimeSpan? AfgangTidspunkt { get; set; }
        
        public int BeskatningLavUge { get; set; }
        public int BeskatningHoejUge { get; set; }

        public int BeskatningLavWeekend { get; set; }
        public int BeskatningHoejWeekend { get; set; }

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
        public byte[] Bemaerkninger { get; set; }
        public byte[] Beskrivelse { get; set; }

    }
}
