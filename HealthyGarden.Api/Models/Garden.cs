using System;

namespace HealthyGarden.Api.Models
{
    public class Garden
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        //public Status Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
