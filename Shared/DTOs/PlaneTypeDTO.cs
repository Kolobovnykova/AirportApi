namespace Shared.DTOs
{
    public class PlaneTypeDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string NumberOfSeats { get; set; }
        public string CarryingCapacity { get; set; }
        public string MaxRange { get; set; }
        public string MaxSpeed { get; set; }
        public string MaxAltitude { get; set; }
    }
}