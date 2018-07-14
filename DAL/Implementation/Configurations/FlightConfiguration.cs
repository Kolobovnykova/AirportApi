using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class FlightConfiguration
    {
        public FlightConfiguration(EntityTypeBuilder<Flight> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.DateOfArrival).IsRequired();
            entityBuilder.Property(x => x.Destination).IsRequired();
            entityBuilder.Property(x => x.Departure).IsRequired();
            entityBuilder.Property(x => x.DateOfDeparture).IsRequired();
        }
    }
}