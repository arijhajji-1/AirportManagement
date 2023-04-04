using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        private readonly IUnitOfWork uow ; 
        //public ServiceFlight(IUnitOfWork uow)
        //{
        //    this.uow = uow;
        //}

        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        //public void add(flight flight)
        //{
        //    uow.repository<flight>().add(flight);
        //    uow.save(); 
        //}

        //public void update(flight flight)
        //{
        //    uow.repository<flight>().update(flight);
        //    uow.save(); 
        //}

        //public  ilist<flight> getall()
        //{
        //    return uow.repository<flight>().getall().tolist() ;
        //}




        //TP2-Q3: Créer la propriété Flights et l’initialiser à une liste vide
        public List<Flight> Flights { get; set; } = new List<Flight>();

        //TP2-Q6: Implémenter la méthode GetFlightDates(string destination)
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
            for (int j = 0; j < Flights.Count; j++)
                if (Flights[j].Destination.Equals(destination))
                    ls.Add(Flights[j].FlightDate);
            return ls;
            ////TP2-Q7: Reformuler la requête avec foreach
            //List<DateTime> ls = new List<DateTime>();
            //foreach (Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;

            ////TP2-Q9: Reformuler la méthode en utilisant LINQ
            //IEnumerable<DateTime> req = from f in Flights
            //                            where f.Destination.Equals(destination)
            //                            select f.FlightDate;
            //return req.ToList();
            //with LINQ language

            ////TP2-Q19: Reformuler la méthode en utilisant Lambda Expression
            // IEnumerable<DateTime> reqLambda = Flights.Where(f => f.Destination.Equals(destination)).Select(f => f.FlightDate);
            //return reqLambda.ToList();
        }



        //TP2-Q8: Implémenter la méthode GetFlights(string filterType, string filterValue)
        public void GetFlights(string filterValue,Func<string,Flight,bool> condition)
        {
            foreach (Flight f in Flights)
            {
                if (condition(filterValue,f))
                    Console.WriteLine(f);
            }
        }
        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.Plane == plane
                      select new { f.FlightDate, f.Destination };
             // var reqLambda = Flights.Where(f => f.Plane == plane).Select(p => new { f.FlightDate, f.Destination });
            foreach (var v in req)
                Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7
                      select f;
            // var reqLambda = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7);
            return req.Count();
        }

        public double DurationAverage(string destination)
        {
            return (from f in Flights
                    where f.Destination.Equals(destination)
                    select f.EstimatedDuration).Average();
            // return Flights.Where(f=>f.Destination.Equals(destination)).Select(f=> f.EstimatedDuration).Average();
        }
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;
            return req;
            // var reqLambda = Flights.OrderByDescending(f => f.EstimatedDuration);
        }

        //public IEnumerable<string> SeniorTravellers(Flight f)
        //{
        //    var oldTravellers = from p in f.Passengers.OfType<Traveller>()
        //                        orderby p.BirthDate
        //                        select p.Nationality;
        //    // var reqLambda = f.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);

        //    return oldTravellers.Take(3);
        //    //if we want to skip 3
        //    //return oldTravellers.Skip(3);
        //}
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
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
            return req;
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            /*
              var quer = from p in flight.Passengers.OfType<Traveller>().ToList()
                          .OrderByDescending(p => p.BirthDate).Take(3)
                         select p;
            */

            // var query = flight.Passengers.OfType<Traveller>().ToList()
            //             .OrderByDescending(p=>p.BirthDate).Take(3);
            // return query;
            return null; 
        }

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights2()
        {
            var query = from f in Flights
                        group f by f.Destination; // ki nestaamlou group menestaamlouch select

            //var query = Flights.GroupBy(f=>f.Destination)

            foreach(var item in query)
            {
                Console.WriteLine("Destination " + item.Key); 
                foreach(var f in item)
                {
                    Console.WriteLine("Decollage : " + f.FlightDate); 
                }
            }
            return query;

          
        }

        public void Add(Plane entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Plane entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Plane entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Plane, bool>> where)
        {
            throw new NotImplementedException();
        }

        Plane IService<Plane>.GetById(params object[] id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Plane> IService<Plane>.GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plane> GetMany(Expression<Func<Plane, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Plane Get(Expression<Func<Plane, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Action<Plane> FlightDetailsDel { get; set; }
        public Func<string,double> DurationAverageDel { get; set; }
        
        public ServiceFlight()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsDel = delegate (Plane plane) // (Plane plane) =>
            {
                var req = from f in Flights
                          where f.Plane == plane
                          select new { f.FlightDate, f.Destination };
                foreach (var v in req)
                    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);

            };


            DurationAverageDel = destination =>
            {
                
                return (from f in Flights
                        where f.Destination.Equals(destination)
                        select f.EstimatedDuration).Average();
            }; 
        }

    }
}