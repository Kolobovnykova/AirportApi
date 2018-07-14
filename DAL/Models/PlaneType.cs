using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PlaneType : Entity
    {
        [Required, MaxLength(50)]
        public string Model { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public int CarryingCapacity { get; set; }
        [Required]
        public int MaxRange { get; set; }
        [Required]
        public int MaxSpeed { get; set; }
        [Required]
        public int MaxAltitude { get; set; }
     //   public Plane Plane { get; set; }
    }
}