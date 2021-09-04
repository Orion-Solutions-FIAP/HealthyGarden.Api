namespace HealthyGarden.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public bool IsAutomatic { get; set; }
        public decimal MinimumMoisture { get; set; }
        public decimal MaximumMoisture { get; set; }
        public decimal MinimumTemperature { get; set; }
        public decimal MaximumTemperature { get; set; }
    }
}
