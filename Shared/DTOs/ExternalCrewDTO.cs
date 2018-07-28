using System.Collections.Generic;

namespace Shared.DTOs
{
    public class ExternalCrewDTO
    {
        public int id { get; set; }
        public List<ExternalPilotDTO> pilot { get; set; }
        public List<ExternalStewardessDTO> stewardess { get; set; }
    }
}