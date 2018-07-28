using System;

namespace Shared.DTOs
{
    public class ExternalPilotDTO
    {
        public int id { get; set; }
        public int crewId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int exp { get; set; }
    }
}