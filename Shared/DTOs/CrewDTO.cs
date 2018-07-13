using System.Collections.Generic;

namespace Shared.DTOs
{
    public class CrewDTO
    {
        public int Id { get; set; }
        public PilotDTO Pilot { get; set; }
        public List<StewardessDTO> Stewardesses { get; set; }
    }
}