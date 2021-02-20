using System;

namespace CustomerVehicle.Service.Application.DataAccessObjects
{
    public interface ICustomerDTO
    {
        string Forename { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
