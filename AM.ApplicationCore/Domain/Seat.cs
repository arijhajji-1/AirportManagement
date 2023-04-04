using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        [Required(ErrorMessage ="Le champ Name doit être obligatoire"), MinLength(1)]
        public string Name { get; set; }
        public string SeatNumber { get; set; }

        [Range(0, 20)]
        public int Size { get; set; }

        [ForeignKey("Plane")]
        public int? PlaneFK; // pour forcer le nom de la clé etrangére
        
        public virtual Plane Plane { get; set; }

        public virtual Section Section { get; set; }

        public virtual List<Reservation>? Reservations { get; set; }
    }
}
