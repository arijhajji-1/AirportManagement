using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {   
        public int PassengerId { get; set; }
        //[DisplayName("Date Of Birth")]
        [Display(Name = "Date Of Birth"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key, StringLength(7)]
        public int PassportNumber { get; set; }
        //[DatatType(Datatype.EmailAddress)]
        [EmailAddress]
        public String EmailAddress { get; set; }

      
        public FullName FullName { get; set; }

        [RegularExpression("[0-9]{8}")]
        public String TelNumber { get; set; }

        public Reservation reservation { get; set; }



        //public bool CheckProfile(string Fn, string Ln, string Em = null)
        //{
        //    if (Em != null)
        //    {
        //        return Fn == FirstName && Ln == LastName && Em == EmailAddress;
        //    }
        //    return Fn == FirstName && Ln == LastName;
        //}
        public virtual void PassengerType()
        {
            Console.WriteLine("I'm a passenger");
        }            
        public List<Ticket>? Tickets { get; set; }
       
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
