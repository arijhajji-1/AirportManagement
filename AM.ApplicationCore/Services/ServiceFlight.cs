using AM.ApplicationCore.Infterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set;} = new List<Flight>();
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public ServiceFlight()
        {

            // DurationAverageDel = DurationAverage;
            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };
            // FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.Plane == p
                          select new { f.FlightDate, f.Destination };
                foreach (var v in req)
                    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
            };
        }

        /*List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++)
            {
                Flight flight = Flights[i];
                if (flight.Destination == destination)
                {
                    result.Add(flight.FlightDate);
                }
            }
            return result;
        }*/

        /*IEnumerable<DateTime> GetFlightDates(string destination)
        {
            for (int i = 0; i < Flights.Count; i++)
            {
                Flight flight = Flights[i];
                if (flight.Destination == destination)
                {
                    yield return flight.FlightDate;
                }
            }
        }*/

        /*IEnumerable<DateTime> GetFlightDates(string destination)
        {
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    yield return flight.FlightDate;
                }
            }
        }*/
        ///  question 8 
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    {
                        var result = Flights.Where(f => f.Destination == filterValue).ToList();
                        foreach (var f in result)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "Departure":
                    {
                        var result = Flights.Where(f => f.Departure == filterValue).ToList();
                        foreach (var f in result)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "FlightDate":
                    {
                        var result = Flights.Where(f => f.FlightDate == DateTime.Parse(filterValue)).ToList();
                        foreach (var f in result)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "FlightId":
                    {
                        var result = Flights.Where(f => f.FlightId == int.Parse(filterValue)).ToList();
                        foreach (var f in result)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    {
                        var result = Flights.Where(f => f.EffectiveArrival == DateTime.Parse(filterValue)).ToList();
                        foreach (var f in result)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    {
                        var result = Flights.Where(f => f.EstimatedDuration == int.Parse(filterValue)).ToList();
                        foreach (var f in result)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
            }
        }
        //quest9
        IEnumerable<DateTime> GetFlightDates(string destination)
        {
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //    {
            //        yield return flight.FlightDate;
            //    }
            //}

            //9
            IEnumerable<DateTime> query = from f in Flights
                                          where f.Destination == destination
                                          select f.FlightDate;
            return query;
        }
        //quest10
        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights
                        where f.Plane.PlaneId == plane.PlaneId
                        select new { f.FlightDate, f.Destination };
            foreach (var item in query)
            {
                Console.WriteLine(item.Destination + item.FlightDate);
            }

        }
        //quest11
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where ((f.FlightDate >= startDate) && (startDate - f.FlightDate).TotalDays < 7)
                        select f;
            ;


            return query.Count();


            //2eme methode
            /* return Flights.Count(f => ((f.FlightDate >= startDate) && (startDate - f.FlightDate).TotalDays < 7)
                          );*/

        }
        public double DurationAverage(string destination)
        {
            var query = from f in Flights
                        where (f.Destination == destination)
                        select f.EstimatedDuration;
            return query.Average();


        }
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var query = from f in Flights
                        orderby f.EstimatedDuration descending
                        select f;
            return query;

        }
       

       
        List<DateTime> IServiceFlight.GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
          
            IEnumerable<DateTime> req = from f in Flights
                                        where f.Destination.Equals(destination)
                                        select f.FlightDate;

            return req.ToList();
        }


        public IEnumerable<Traveller> SeniorTravellers(Flight f)
        {
            var oldTravellers = from p in f.Passengers.OfType<Traveller>()
                                orderby p.BirthDate
                                select p;

            // var reqLambda = f.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);


            return oldTravellers.Take(3);
            //if we want to skip 3
            //return oldTravellers.Skip(3);
        }

        public IGrouping<string, IEnumerable<Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            //  var reqLambda = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " + f.FlightDate);

            }
            return (IGrouping<string, IEnumerable<Flight>>)req;
        }
        //pour tester la méthode DestinationGroupedFlights
        public void diplay()
        {
            var result =
                (from f in Flights
                 group f by f.Destination);

            foreach (var destination in result)
            {
                Console.WriteLine(" destination =  " + destination.Key); // key = city
                foreach (var flight in destination)
                {
                    Console.WriteLine("Flights Details" + flight.FlightDate);

                }
            }

        }
    }
}
