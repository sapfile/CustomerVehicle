using System;

namespace CustomerVehicle.Service.Application.DataAccessObjects
{
    public interface IVehicleDTO
    {
        string RegistrationNumber { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        int EngineSize { get; set; }
        DateTime RegistationDate { get; set; }
        string InteriorColour { get; set; }
    }
}
