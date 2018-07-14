using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class PlaneTypeConfiguration
    {
        public PlaneTypeConfiguration(EntityTypeBuilder<PlaneType> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Model).IsRequired();
            entityBuilder.Property(x => x.CarryingCapacity).IsRequired();
            entityBuilder.Property(x => x.MaxAltitude).IsRequired();
            entityBuilder.Property(x => x.MaxRange).IsRequired();
            entityBuilder.Property(x => x.MaxSpeed).IsRequired();
            entityBuilder.Property(x => x.Model).IsRequired();
            entityBuilder.Property(x => x.NumberOfSeats).IsRequired();
        }
    }
}