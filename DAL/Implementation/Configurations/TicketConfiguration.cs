using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Implementation.Configurations
{
    public class TicketConfiguration
    {
        public TicketConfiguration(EntityTypeBuilder<Ticket> entityBuilder)
        {
//            entityBuilder.HasKey(x => x.Id);
//            entityBuilder.Property(x => x.Price).IsRequired();
//            entityBuilder.HasOne(x => x.Flight).WithMany(x => x.Tickets).HasForeignKey(x => x.FlightId);
        }
    }
}