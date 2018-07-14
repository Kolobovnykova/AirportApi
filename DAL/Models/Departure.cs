using System;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public int CrewId { get; set; }
        public Crew Crew { get; set; }
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
    }
}