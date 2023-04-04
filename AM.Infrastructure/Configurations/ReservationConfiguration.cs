using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(r => r.Passenger)
                .WithMany(p => p.Reservations)
                .HasForeignKey(f => f.PassengerFk);

            builder.HasOne(r => r.Seat)
                .WithMany(p => p.Reservations)
                .HasForeignKey(f => f.SeatFk);

            builder.HasKey(r => new { r.PassengerFk, r.SeatFk, r.DateReservation });

        }
    }
}
