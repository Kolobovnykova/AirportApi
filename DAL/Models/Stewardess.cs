using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Stewardess : Entity
    {
        [Required, MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public virtual int CrewId { get; set; }
       // public Crew Crew { get; set; }
    }
}