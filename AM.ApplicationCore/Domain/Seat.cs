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
        public Section section { get; set; }
        public Seat() { }

        public Reservation reservation { get; set; }

        [ForeignKey("Plane")]
        public int? PlaneFk { get; set; }
        public  Plane plane { get; set; }



    }
}
