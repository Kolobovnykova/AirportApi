using System;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public string Name { get; set; }
        public int PlaneTypeId { get; set; }
        public PlaneType PlaneType { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Lifetime { get; set; }
        public Departure Departure { get; set; }
    }
}