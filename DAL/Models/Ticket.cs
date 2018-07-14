using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Ticket : Entity
    {
        [Required]
        public int FlightId { get; set; }
       // public Flight Flight { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}