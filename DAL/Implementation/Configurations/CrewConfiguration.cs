using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class CrewConfiguration
    {
        public CrewConfiguration(EntityTypeBuilder<Crew> entityBuilder)
        {
//            entityBuilder.HasKey(x => x.Id);
//            entityBuilder.Property(x => x.Pilot).IsRequired();
//            entityBuilder.HasOne(x => x.Pilot).WithOne().HasForeignKey<Crew>(x => x.PilotId);

            
        }
    }
}