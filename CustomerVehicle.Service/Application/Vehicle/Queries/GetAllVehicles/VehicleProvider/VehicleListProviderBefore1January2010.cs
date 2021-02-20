using CustomerVehicle.Repository.Interfaces.Application;
using System;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    internal class VehicleListProviderBefore1January2010 : VehicleListProviderBaseWithParameter
    {
        public VehicleListProviderBefore1January2010(
            IVehicleRepository vehicleRepository)
            : base(vehicleRepository)
        {
            expression = x => x.RegistationDate < new DateTime(2010, 1, 1);
        }
    }
}