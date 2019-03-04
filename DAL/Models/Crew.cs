using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Crew : Entity
    {
        [Required]
        public virtual Pilot Pilot { get; set; }
        [Required]
        public virtual ICollection<Stewardess> Stewardesses { get; set; }
    }
}
