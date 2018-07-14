using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Departure : Entity
    {
        [Required]
        public virtual int FlightId { get; set; }
        [Required]
        public virtual Flight Flight { get; set; }
        [Required]
        public virtual DateTime DateOfDeparture { get; set; }
        [Required]
        public virtual Crew Crew { get; set; }
        [Required]
        public virtual Plane Plane { get; set; }
    }
}