using CustomerVehicle.Repository.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    internal class VehicleListProviderAgeBetween20and30 : VehicleListProviderBaseWithParameter
    {
        public VehicleListProviderAgeBetween20and30(
            IVehicleRepository vehicleRepository)
            :base(vehicleRepository)
        {
            expression = x => (DateTime.UtcNow.Year - x.Customer.DateOfBirth.Year) >= 20 && 
                              (DateTime.UtcNow.Year - x.Customer.DateOfBirth.Year) <= 30;
        }
    }
}