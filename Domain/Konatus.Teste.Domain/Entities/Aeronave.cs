namespace Konatus.Teste.Domain.Entities
{
    public class Aeronave
    {
        public string Prefix { get; set; }
        public decimal MaxDepartureWeight { get; set; }
        public decimal MaxLandingWeight { get; set; }
        public bool Active { get; set; }
        public string AircraftModel { get; set; }
    }
}