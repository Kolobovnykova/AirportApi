using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class StewardessConfiguration
    {
        public StewardessConfiguration(EntityTypeBuilder<Stewardess> entityBuilder)
        {
//            entityBuilder.HasKey(x => x.Id);
//            entityBuilder.Property(x => x.FirstName).IsRequired();
//            entityBuilder.Property(x => x.LastName).IsRequired();
//            entityBuilder.Property(x => x.DateOfBirth).IsRequired();
//            entityBuilder.HasOne(x => x.Crew).WithMany(x => x.Stewardesses).HasForeignKey(x => x.CrewId);
        }
    }
}