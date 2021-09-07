using System.ComponentModel.DataAnnotations;

namespace HealthyGarden.Domain.Entities
{
    public class Setting
    {
        [Required]
        public int GardenId{ get; set; }
        [Required]
        public bool IsAutomatic { get; set; }
        [Required]
        public decimal MinimumMoisture { get; set; }
        [Required]
        public decimal MaximumMoisture { get; set; }
        [Required]
        public decimal MinimumTemperature { get; set; }
        [Required]
        public decimal MaximumTemperature { get; set; }
    }
}
