using System.ComponentModel.DataAnnotations.Schema;

namespace NapaTraineeAPI.Models
{
    public class Country
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }

        // Navigation property
        public ICollection<Port>? Ports { get; set; }
    }
}
