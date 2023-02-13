using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{
    public static class TestData
    {
        public static Plane BoingPlane = new Plane { MyPlaneType = PlaneType.Boing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };
        public static Plane Airbusplane = new Plane { MyPlaneType = PlaneType.Airbus, Capacity = 250, ManufactureDate = new DateTime(2020, 11, 11) };
        // Staffs
        public static Staff captain = new Staff { FirstName = "captain", LastName = "captain", EmailAdress = "captain.captain@gmail.com", BirthDate = new DateTime(1965, 01, 01), EmploymentDate = new DateTime(1999, 01, 01), Salary = 99999 };
        
        public static Traveller traveller1 = new Traveller { FirstName = "traveller1", LastName = "traveller1", EmailAdress = "traveller1.traveller1@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "no troubles", Nationality = "American" };
        public static Traveller traveller2 = new Traveller { FirstName = "traveller2", LastName = "traveller2", EmailAdress = "traveller2.traveller2@gmail.com", BirthDate = new DateTime(1981, 01, 01), HealthInformation = "Some troubles", Nationality = "French" };
     
        // Flights
        // Affect all passengers to flight1
        public static Flight flight1 = new Flight
        {
            FlightDate = new DateTime(2022, 01, 01, 15, 10, 10),
            Destination = "Paris",
            EffectiveArrival = new DateTime(2022, 01, 01, 17, 10, 10),
            EstimatedDuration = 110,
            Passengers = new List<Passenger> { captain,  traveller1, traveller2 }
       ,
            Plane = Airbusplane
        };
        public static Flight flight2 = new Flight { FlightDate = new DateTime(2022, 02, 01, 21, 10, 10), Destination = "Paris", EffectiveArrival = new DateTime(2022, 02, 01, 23, 10, 10), EstimatedDuration = 105, Plane = BoingPlane };
        public static Flight flight4 = new Flight { FlightDate = new DateTime(2022, 04, 01, 6, 10, 10), Destination = "Madrid", EffectiveArrival = new DateTime(2022, 04, 01, 8, 10, 10), EstimatedDuration = 130, Plane = BoingPlane };
        public static Flight flight6 = new Flight { FlightDate = new DateTime(2022, 06, 01, 20, 10, 10), Destination = "Lisbonne", EffectiveArrival = new DateTime(2022, 06, 01, 22, 30, 10), EstimatedDuration = 200, Plane = Airbusplane };

        //test list
        public static List<Flight> listFlights = new List<Flight> { flight1, flight2, flight4, flight6 };
    }
}
