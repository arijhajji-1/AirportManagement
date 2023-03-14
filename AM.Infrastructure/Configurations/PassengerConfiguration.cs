using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            //builder.Property(p => p.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(80)
            //    .HasDefaultValue("name")
            //    .HasColumnType("nchar");
            builder.OwnsOne(p => p.FullName, fn =>
            {
                fn.Property(a => a.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                fn.Property(a => a.LastName).HasColumnName("PassLastName").HasMaxLength(30);

            });

            //builder
            //    .hasdiscriminator<int>("istraveller")
            //    .hasvalue<passenger>(0)
            //    .hasvalue<staff>(1)
            //    .hasvalue<traveller>(2);


        }


    }
}
