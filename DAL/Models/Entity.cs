using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
