using CustomerVehicle.Service.Application.DataAccessObjects;
using System;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles
{
    public class GetAllVehicleLookupModel : JoinedDTO
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
    }
}