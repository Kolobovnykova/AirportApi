using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public int PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
        public ICollection<Stewardess> Stewardesses { get; set; }
    }
}
