using System;

namespace Shared.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public int DepartureId { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public int DestinationId { get; set; }
        public DateTime DateOfArrival { get; set; }
        public int[] TicketsId { get; set; }
    }
}