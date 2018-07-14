namespace DAL.Models
{
    public class Ticket : Entity
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public decimal Price { get; set; }
    }
}