using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Flight : Entity
    {
        public Airport DepartureAirport { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DateOfArrival { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
