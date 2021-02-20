using System;

namespace CustomerVehicle.Service.Application.DataAccessObjects
{
    public abstract class CustomerDTO : ICustomerDTO
    {
        public virtual string Forename { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
    }
}
