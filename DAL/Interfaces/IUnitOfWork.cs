using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Crew> CrewRepository { get; set; }
        IRepository<Plane> PlaneRepository { get; set; }
        IRepository<PlaneType> PlaneTypeRepository { get; set; }
        IRepository<Flight> FlightRepository { get; set; }
        IRepository<Ticket> TicketRepository { get; set; }
        IRepository<Departure> DepartureRepository { get; set; }
        IRepository<Stewardess> StewardessRepository { get; set; }
        IRepository<Pilot> PilotRepository { get; set; }
        void Seed();
        void DropDb();
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}