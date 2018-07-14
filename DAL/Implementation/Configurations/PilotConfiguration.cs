using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class PilotConfiguration
    {
        public PilotConfiguration(EntityTypeBuilder<Pilot> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.FirstName).IsRequired();
            entityBuilder.Property(x => x.LastName).IsRequired();
            entityBuilder.Property(x => x.DateOfBirth).IsRequired();
            entityBuilder.Property(x => x.Experience).IsRequired();
        }
    }
}