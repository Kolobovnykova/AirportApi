using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private readonly IDataSource dataSource;

        public FlightRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Flight Get(int id)
        {
            return dataSource.Flights.Find(p => p.Id == id);
        }

        public IEnumerable<Flight> GetAll()
        {
            return dataSource.Flights;
        }

        public void Create(Flight entity)
        {
            dataSource.Flights.Add(entity);
        }

        public void Update(Flight entity)
        {
            var flight = Get(entity.Id);

            if (entity.DepartureAirport != null)
            {
                flight.DepartureAirport = entity.DepartureAirport;
            }

            if (entity.DestinationAirport != null)
            {
                flight.DestinationAirport = entity.DestinationAirport;
            }

            if (entity.Tickets != null)
            {
                flight.Tickets = entity.Tickets;
            }

            if (entity.DateOfArrival >= DateTime.MinValue)
            {
                flight.DateOfArrival = entity.DateOfArrival;
            }

            if (entity.DateOfDeparture >= DateTime.MinValue)
            {
                flight.DateOfDeparture = entity.DateOfDeparture;
            }
        }

        public void Delete(int id)
        {
            dataSource.Flights.Remove(Get(id));
        }
    }
}