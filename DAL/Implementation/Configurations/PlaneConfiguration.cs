using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class PlaneConfiguration
    {
        public PlaneConfiguration(EntityTypeBuilder<Plane> entityBuilder)
        {
//            entityBuilder.HasKey(x => x.Id);
//            entityBuilder.Property(x => x.Name).IsRequired();
//            entityBuilder.Property(x => x.DateOfRelease).IsRequired();
//            entityBuilder.Property(x => x.Lifetime).IsRequired();
//            entityBuilder.HasOne(x => x.PlaneType).WithOne(x => x.Plane).HasForeignKey<Plane>(x => x.PlaneTypeId);
        }
    }
}