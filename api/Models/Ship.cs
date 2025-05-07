using System.ComponentModel.DataAnnotations.Schema;

namespace NapaTraineeAPI.Models
{
    public class Ship
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("max_speed")]
        public double MaxSpeed { get; set; }

        // Navigation property
        public ICollection<Voyage>? Voyages { get; set; }
    }
}
