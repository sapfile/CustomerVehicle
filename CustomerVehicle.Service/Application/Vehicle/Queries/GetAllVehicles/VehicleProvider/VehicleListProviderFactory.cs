using CustomerVehicle.Repository.Interfaces.Application;
using System;
using System.Reflection;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    public class VehicleListProviderFactory
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleListProviderFactory(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        internal VehicleListProviderBase VehicleListProviderType(int reportType)
        {
            var reportTypeEnum = (ReportTypes)reportType;

            switch (reportTypeEnum)
            {
                case ReportTypes.All:

                    return new VehicleListProviderAll(_vehicleRepository);
                    
                    
                
                default:

                    var ns = $"{GetType().Namespace}.VehicleListProvider{reportTypeEnum}";

                    Type t = Type.GetType(ns);

                    return (VehicleListProviderBase)Activator.CreateInstance(t, new object[] { _vehicleRepository });

            }
        }
    }
}
