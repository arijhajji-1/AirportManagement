// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

using System.Numerics;
using Plane = AM.ApplicationCore.Domain.Plane;
//Plane p1 = new Plane();

//p1.Capacity = 200;
//p1.ManufactureDate = new DateTime(2015, 01, 16);
//p1.PlaneType = PlaneType.Boing;
//p1.PlaneKey = 2;

//Console.WriteLine(p1);

//Plane p2 = new Plane(10, new DateTime(2015, 01, 16), PlaneType.Airbus);

//Console.WriteLine(p2);

//Passenger passenger = new Passenger();
//passenger.PassengerType();

//Staff staff = new Staff();
//staff.PassengerType();

//Traveller traveller = new Traveller();
//traveller.PassengerType();

//Console.WriteLine("Hello, World!");

//ServiceFlight serviceFlight = new ServiceFlight();
////serviceFlight.Flights = TestData.listFlights;
////Methode Anonyme
//serviceFlight.GetFlights("Paris", 
//    delegate (string value, Flight f) 
//    { return f.Destination == value; }
//);
////expression lamda
//serviceFlight.GetFlights("11/11/2022",
//    delegate (string value, Flight f)
//    { return f.FlightDate ==DateTime.Parse( value); }
//);

var am = new AmContext();

// ======= add

//
//am.Flights.Add(new Flight()
//{
//    Departure = "Tunis",
//    Destination = "Sousse",
//    FlightDate = new DateTime(2022, 2, 2),
//    EffectiveArrival = DateTime.Now,
//    EstimatedDuration = 1,
//    Plane = new Plane()
//    {
//        Capacity = 15,
//        ManufactureDate = DateTime.Now,
//        PlaneType = PlaneType.Boing
//    }
//}); 

//am.SaveChanges();





// ===== affichage
foreach (var item in am.Flights.ToList())
{
    Console.WriteLine(item.FlightId + ", " + item.Plane.Capacity);
}