using System;
using System.Threading.Tasks;
using DAL.Implementation.Repositories;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
       // private readonly IDataSource dataSource;
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

        public IRepository<Flight> FlightRepository => flightRepository ?? (flightRepository = new FlightRepository(context));
        public IRepository<Crew> CrewRepository => crewRepository ?? (crewRepository = new CrewRepository(context));
        public IRepository<Departure> DepartureRepository => departureRepository ?? (departureRepository = new DepartureRepository(context));
        public IRepository<Plane> PlaneRepository => planeRepository ?? (planeRepository = new PlaneRepository(context));
        public IRepository<Pilot> PilotRepository => pilotRepository ?? (pilotRepository = new PilotRepository(context));
        public IRepository<PlaneType> PlaneTypeRepository => planeTypeRepository ?? (planeTypeRepository = new PlaneTypeRepository(context));
        public IRepository<Stewardess> StewardessRepository => stewardessRepository ?? (stewardessRepository = new StewardessRepository(context));
        public IRepository<Ticket> TicketRepository => ticketRepository ?? (ticketRepository = new TicketRepository(context));


        public int SaveChages()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}