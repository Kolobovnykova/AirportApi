using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IDataSource
    {
        List<Flight> Flights { get; set; }
        List<Ticket> Tickets { get; set; }
        List<Departure> Departures { get; set; }
        List<Stewardess> Stewardesses { get; set; }
        List<Pilot> Pilots { get; set; }
        List<Crew> Crews { get; set; }
        List<Plane> Planes { get; set; }
        List<PlaneType> PlaneTypes { get; set; }

        List<TEntity> Set<TEntity>();
    }
}