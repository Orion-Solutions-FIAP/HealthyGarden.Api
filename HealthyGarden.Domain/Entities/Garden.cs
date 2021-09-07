using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HealthyGarden.Domain.Entities
{
    public class Garden
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime CreatedAt { get; set; }
    }
}
