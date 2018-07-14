using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Pilot : Entity
    {
        [Required, MaxLength(40)]
        public string FirstName { get; set; }
        [Required, MaxLength(60)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Experience { get; set; }
    }
}