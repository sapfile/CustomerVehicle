using System;

namespace CustomerVehicle.Service.Application.DataAccessObjects
{
    public abstract class VehicleDTO : IVehicleDTO
    {
        public string RegistrationNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int EngineSize { get; set; }
        public DateTime RegistationDate { get; set; }
        public string InteriorColour { get; set; }
    }
}
