using System;
namespace HealthyGarden.Domain.Entities
{
    public class Historic
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public DateTime IrrigationDate { get; set; }
        public decimal Moisture { get; set; }
        public decimal Temperature { get; set; }
    }
}
