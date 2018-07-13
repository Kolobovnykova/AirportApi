using System;

namespace Shared.DTOs
{
    public class DepartureDTO
    {
        public int Id { get; set; }
        public FlightDTO Flight { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public CrewDTO Crew { get; set; }
        public PlaneDTO Plane { get; set; }
    }
}