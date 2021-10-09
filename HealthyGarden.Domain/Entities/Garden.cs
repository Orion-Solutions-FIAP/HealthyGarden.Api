using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HealthyGarden.Domain.Entities.Enum;

namespace HealthyGarden.Domain.Entities
{
    public class Garden
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public MoistureStatus MoistureStatus { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string MoistureStatusDescription { get; set; }

        [Required]
        public TemperatureStatus TemperatureStatus { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TemperatureStatusDescription { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime CreatedAt { get; set; }
    }
}
