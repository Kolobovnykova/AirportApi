using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Plane : Entity
    {  
        [Required, MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public PlaneType PlaneType { get; set; }
        [Required]
        public DateTime DateOfRelease { get; set; }
        [Required]
        public int Lifetime { get; set; }
    }
}