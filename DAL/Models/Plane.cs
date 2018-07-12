using System;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public string Name { get; set; }
        public PlaneType PlaneType { get; set; }
        public DateTime DateOfRelease { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}