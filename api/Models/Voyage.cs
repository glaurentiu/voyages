using System.ComponentModel.DataAnnotations.Schema;

namespace NapaTraineeAPI.Models
{
    public class Voyage
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("ship_id")]
        public int ShipId { get; set; }

        [Column("departure_port_id")]
        public int DeparturePortId { get; set; }

        [Column("arrival_port_id")]
        public int ArrivalPortId { get; set; }

        [Column("start_timestamp")]
        public DateTime StartTimestamp { get; set; }

        [Column("end_timestamp")]
        public DateTime EndTimestamp { get; set; }

        // Navigation properties
        public  Ship? Ship { get; set; }
        public  Port? DeparturePort { get; set; }
        public  Port? ArrivalPort { get; set; }
    }
}
