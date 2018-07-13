using System;

namespace Shared.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime DateOfArrival { get; set; }
        public int[] TicketsId { get; set; }
    }
}