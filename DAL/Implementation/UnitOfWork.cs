using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataSource dataSource;

        public UnitOfWork(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        
        IRepository<Pilot> pilotRepository;
        IRepository<Crew> crewRepository;
        IRepository<Plane> planeRepository;
        IRepository<Flight> flightRepository;
        IRepository<Ticket>  ticketRepository;
        IRepository<Departure> departureRepository;
        IRepository<Stewardess> stewardessRepository;
        IRepository<PlaneType> planeTypeRepository;

        public IRepository<Flight> FlightRepository => flightRepository ?? (flightRepository = new Repository<Flight>(dataSource));
        public IRepository<Crew> CrewRepository => crewRepository ?? (crewRepository = new Repository<Crew>(dataSource));
        public IRepository<Departure> DepartureRepository => departureRepository ?? (departureRepository = new Repository<Departure>(dataSource));
        public IRepository<Plane> PlaneRepository => planeRepository ?? (planeRepository = new Repository<Plane>(dataSource));
        public IRepository<Pilot> PilotRepository => pilotRepository ?? (pilotRepository = new Repository<Pilot>(dataSource));
        public IRepository<PlaneType> PlaneTypeRepository => planeTypeRepository ?? (planeTypeRepository = new Repository<PlaneType>(dataSource));
        public IRepository<Stewardess> StewardessRepository => stewardessRepository ?? (stewardessRepository = new Repository<Stewardess>(dataSource));
        public IRepository<Ticket> TicketRepository => ticketRepository ?? (ticketRepository = new Repository<Ticket>(dataSource));


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