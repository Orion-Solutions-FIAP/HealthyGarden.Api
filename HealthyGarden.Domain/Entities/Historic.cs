using System;
namespace HealthyGarden.Domain.Entities
{
    public class Historic
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public DateTime IrrigationDate { get; set; }
        public short Moisture { get; set; }
        public short Temperature { get; set; }
    }
}
