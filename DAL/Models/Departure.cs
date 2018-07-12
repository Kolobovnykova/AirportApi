using System;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public Flight Flight { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}