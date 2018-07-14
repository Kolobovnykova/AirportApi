using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Flight : Entity
    {
        public string PointOfDeparture { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime DateOfArrival { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Departure Departure { get; set; }
    }
}
