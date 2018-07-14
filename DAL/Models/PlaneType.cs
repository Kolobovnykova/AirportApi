namespace DAL.Models
{
    public class PlaneType : Entity
    {
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public int CarryingCapacity { get; set; }
        public int MaxRange { get; set; }
        public int MaxSpeed { get; set; }
        public int MaxAltitude { get; set; }
        public Plane Plane { get; set; }
    }
}