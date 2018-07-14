using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Flight : Entity
    {
        [Required, MaxLength(100)]
        public string PointOfDeparture { get; set; }
        [Required]
        public DateTime DateOfDeparture { get; set; }
        [Required, MaxLength(100)]
        public string Destination { get; set; }
        [Required]
        public DateTime DateOfArrival { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        [Required]
        public Departure Departure { get; set; }
    }
}
