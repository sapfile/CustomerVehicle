using System;

namespace CustomerVehicle.Persistence.Entities
{
    public class Vehicle : EntityBase
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int EngineSize { get; set; }
        public DateTime RegistationDate { get; set; }
        public string InteriorColour { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}