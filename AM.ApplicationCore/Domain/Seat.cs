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
        [Required(ErrorMessage = "Name obligatoire"), MinLength(1)]
        public String Name { get; set; }
        public int SeatNumber { get; set; }
        [Range(0,20)]
        public int Size { get; set; }
        public virtual Section Section { get; set; }
        public Seat() { }

        public virtual List<Reservation>? Reservations { get; set; }

        [ForeignKey("Plane")]
        public virtual int? PlaneFk { get; set; }
        public virtual Plane plane { get; set; }



    }
}
