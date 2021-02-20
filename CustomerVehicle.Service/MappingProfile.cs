using AutoMapper;
using CustomerVehicle.Persistence.Entities;
using CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer;
using CustomerVehicle.Service.Application.DataAccessObjects;
using CustomerVehicle.Service.Application.Vehicle.Command.UpdateVehicle;
using CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles;
using CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle;

namespace CustomerVehicle.Service
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<VehicleDTO, Vehicle>();
            CreateMap<Vehicle, VehicleDTO>();

            CreateMap<Vehicle, GetAllVehicleLookupModel>()
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(d => d.VehicleId, opt => opt.MapFrom(s => s.VehicleId))
                .ForMember(d => d.Forename, opt => opt.MapFrom(s => s.Customer.Forename))
                .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.Customer.Surname))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.Customer.DateOfBirth));

            CreateMap<Vehicle, GetVehicleModel>()
                .ForMember(d => d.VehicleId, opt => opt.MapFrom(s => s.VehicleId))
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId));

            CreateMap<UpdateVehicleCommand, Vehicle>();

            CreateMap<Customer, GetCustomerModel>()
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId));

            CreateMap<ImportCustomerCommand, Customer>()
                .ForPath(d => d.Vehicles, op => op.MapFrom(s => s.Vehicles));
        }
    }
}
