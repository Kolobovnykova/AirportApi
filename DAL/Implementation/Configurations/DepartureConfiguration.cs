using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class DepartureConfiguration
    {
        public DepartureConfiguration(EntityTypeBuilder<Departure> entityBuilder)
        {
            entityBuilder.HasKey(d => d.Id);
            entityBuilder.Property(d => d.DateOfDeparture).IsRequired();
         //   entityBuilder.HasOne(e => e.Flight).WithOne(e => e.Departure).HasForeignKey<Departure>(e => e.FlightId);
            entityBuilder.HasOne(e => e.Plane).WithOne(e => e.Departure).HasForeignKey<Departure>(e => e.PlaneId);
        }
    }
}