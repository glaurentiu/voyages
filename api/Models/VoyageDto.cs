namespace NapaTraineeAPI.Models
{
    public class VoyageDto
    {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public string ShipName { get; set; }
        public double ShipMaxSpeed { get; set; } // From your response
        public int DeparturePortId { get; set; }
        public string DeparturePortName { get; set; }
        public string DepartureCountryName { get; set; }
        public int ArrivalPortId { get; set; }
        public string ArrivalPortName { get; set; }
        public string ArrivalCountryName { get; set; }
        public DateTime StartTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
    }
}
