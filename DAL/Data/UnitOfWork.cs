using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataSource dataSource;

        private IRepository<Airport> airpoRepository;
        private IRepository<PlaneType> planeTypeRepository;
        private IRepository<Plane> planeRepository;
        private IRepository<Stewardess> stewardessRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Crew> crewRepository;
        private IRepository<Ticket> ticketRepository;
        private IRepository<Flight> flightRepository;
        private IRepository<Departure> departureRepository;

        public UnitOfWork(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public IRepository<Airport> AirportRepository => airpoRepository ?? new AirportRepository(dataSource);
        public IRepository<PlaneType> PlaneTypeRepository => planeTypeRepository ?? new PlaneTypeRepository(dataSource);
        public IRepository<Plane> PlaneRepository => planeRepository ?? new PlaneRepository(dataSource);
        public IRepository<Stewardess> StewardessRepository => stewardessRepository ?? new StewardessRepository(dataSource);
        public IRepository<Pilot> PilotRepository => pilotRepository ?? new PilotRepository(dataSource);
        public IRepository<Crew> CrewRepository => crewRepository ?? new CrewRepository(dataSource);
        public IRepository<Ticket> TicketRepository => ticketRepository ?? new TicketRepository(dataSource);
        public IRepository<Flight> FlightRepository => flightRepository ?? new FlightRepository(dataSource);
        public IRepository<Departure> DepartureRepository => departureRepository ?? new DepartureRepository(dataSource);

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