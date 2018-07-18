using System.Threading.Tasks;
using DAL.Implementation.Repositories;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AirportContext context;

        public UnitOfWork(AirportContext context)
        {
            this.context = context;
        }
        
        IRepository<Pilot> pilotRepository;
        IRepository<Crew> crewRepository;
        IRepository<Plane> planeRepository;
        IRepository<Flight> flightRepository;
        IRepository<Ticket>  ticketRepository;
        IRepository<Departure> departureRepository;
        IRepository<Stewardess> stewardessRepository;
        IRepository<PlaneType> planeTypeRepository;

        public IRepository<Flight> FlightRepository
        {
            get => flightRepository ?? (flightRepository = new FlightRepository(context));
            set => flightRepository = value;
        }

        public IRepository<Crew> CrewRepository
        {
            get => crewRepository ?? (crewRepository = new CrewRepository(context));
            set => crewRepository = value;
        }

        public IRepository<Departure> DepartureRepository
        {
            get => departureRepository ?? (departureRepository = new DepartureRepository(context));
            set => departureRepository = value;
        }

        public IRepository<Plane> PlaneRepository
        {
            get => planeRepository ?? (planeRepository = new PlaneRepository(context));
            set => planeRepository = value;
        }

        public IRepository<Pilot> PilotRepository
        {
            get => pilotRepository ?? (pilotRepository = new PilotRepository(context));
            set => pilotRepository = value;
        }

        public IRepository<PlaneType> PlaneTypeRepository
        {
            get => planeTypeRepository ?? (planeTypeRepository = new PlaneTypeRepository(context));
            set => planeTypeRepository = value;
        }

        public IRepository<Stewardess> StewardessRepository
        {
            get => stewardessRepository ?? (stewardessRepository = new StewardessRepository(context));
            set => stewardessRepository = value;
        }

        public IRepository<Ticket> TicketRepository
        {
            get => ticketRepository ?? (ticketRepository = new TicketRepository(context));
            set => ticketRepository = value;
        }

        public void Seed()
        {
            AirportDbInitializer.Initialize(context);
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void DropDb()
        {
            throw new System.NotImplementedException();
        }
    }
}