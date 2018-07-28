using System;

namespace Shared.DTOs
{
    public class ExternalStewardessDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int crewId { get; set; }
    }
}