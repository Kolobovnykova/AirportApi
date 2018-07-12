using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public class IDataSource
    {
        public List<Airport> Airports { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Departure> Departures { get; set; }
        public List<Stewardess> Stewardesses { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Crew> Crews { get; set; }
        public List<Plane> Planes { get; set; }
        public List<PlaneType> PlaneTypes { get; set; }
    }
}