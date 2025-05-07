using System.ComponentModel.DataAnnotations.Schema;

namespace NapaTraineeAPI.Models
{
    public class Port
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public  string Name { get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }

        // Navigation properties
        public  Country Country { get; set; }
        public ICollection<Voyage>? DepartingVoyages { get; set; }
        public ICollection<Voyage>? ArrivingVoyages { get; set; }
    }
}
