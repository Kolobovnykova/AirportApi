using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Crew : Entity
    {
      //  public int PilotId { get; set; }
        [Required]
        public virtual Pilot Pilot { get; set; }
        [Required]
        public virtual ICollection<Stewardess> Stewardesses { get; set; }
    }
}
