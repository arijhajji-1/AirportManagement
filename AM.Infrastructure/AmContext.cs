using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AmContext: DbContext
    {
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = (localdb)\mssqllocaldb;" +
                "initial catalog=ArijHajji; integrated security = true");
            optionsBuilder.UseLazyLoadingProxies(true); 

        }

        //data annotation

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Passenger>().Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(80)
                .HasDefaultValue("name")
                .HasColumnType("nchar") ;
        }*/





        // fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PassengerConfiguration()); 
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());



            //modelBuilder.Entity<Passenger>()
            //    .HasDiscriminator<int>("Istraveller")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Staff>(1)
            //    .HasValue<Traveller>(2);


            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Traveller>().ToTable("Traveller");
            modelBuilder.Entity<Passenger>().ToTable("Passenger");
            modelBuilder.Entity<Reservation>().HasOne(r => r.Seat)
                .WithMany(p => p.Reservations)
                .HasForeignKey(f => f.SeatFk);
            //modelBuilder.Entity<Ticket>().HasKey(p => new { p.FlightFk, p.PassengerFk });  
        }

        // change all properties to 100 chars max
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100).HaveColumnType("varchar");
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<double>().HavePrecision(3, 2); 
            
        }

    }
}
