using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace AirportApi.Tests.FakeObjects
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        IRepository<Pilot> pilotRepository;
        ICrewRepository crewRepository;
        IRepository<Plane> planeRepository;
        IRepository<Flight> flightRepository;
        IRepository<Ticket> ticketRepository;
        IRepository<Departure> departureRepository;
        IRepository<Stewardess> stewardessRepository;
        IRepository<PlaneType> planeTypeRepository;


        public IRepository<Flight> FlightRepository
        {
            get => flightRepository ?? (flightRepository = new FakeRepository<Flight>());
            set => flightRepository = value;
        }

        public ICrewRepository CrewRepository
        {
            get => crewRepository ?? (crewRepository = new FakeRepositoryCrew());
            set => crewRepository = value;
        }

        public IRepository<Departure> DepartureRepository
        {
            get => departureRepository ?? (departureRepository = new FakeRepository<Departure>());
            set => departureRepository = value;
        }

        public IRepository<Plane> PlaneRepository
        {
            get => planeRepository ?? (planeRepository = new FakeRepository<Plane>());
            set => planeRepository = value;
        }

        public IRepository<Pilot> PilotRepository
        {
            get => pilotRepository ?? (pilotRepository = new FakeRepository<Pilot>());
            set => pilotRepository = value;
        }

        public IRepository<PlaneType> PlaneTypeRepository
        {
            get => planeTypeRepository ?? (planeTypeRepository = new FakeRepository<PlaneType>());
            set => planeTypeRepository = value;
        }

        public IRepository<Stewardess> StewardessRepository
        {
            get => stewardessRepository ?? (stewardessRepository = new FakeRepository<Stewardess>());
            set => stewardessRepository = value;
        }

        public IRepository<Ticket> TicketRepository
        {
            get => ticketRepository ?? (ticketRepository = new FakeRepository<Ticket>());
            set => ticketRepository = value;
        }


        public void Seed()
        {
            this.Initialize();
        }

        public void DropDb()
        {
            pilotRepository = new FakeRepository<Pilot>();
            stewardessRepository = new FakeRepository<Stewardess>();
            crewRepository = new FakeRepositoryCrew();
            planeRepository = new FakeRepository<Plane>();
            planeTypeRepository = new FakeRepository<PlaneType>();
            flightRepository = new FakeRepository<Flight>();
            ticketRepository = new FakeRepository<Ticket>();
            departureRepository = new FakeRepository<Departure>();
        }

        public void SaveChanges()
        {
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}