using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Crew> CrewRepository { get; }
        IRepository<Plane> PlaneRepository { get; }
        IRepository<PlaneType> PlaneTypeRepository { get; }
        IRepository<Flight> FlightRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<Departure> DepartureRepository { get; }
        IRepository<Stewardess> StewardessRepository { get; }
        IRepository<Pilot> PilotRepository { get; }
        int SaveChages();
        Task<int> SaveChangesAsync();
    }
}