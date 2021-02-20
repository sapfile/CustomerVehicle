using FluentValidation;
using System.Linq;

namespace CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer
{
    public class ImportCustomerCommandValidation : AbstractValidator<ImportCustomerCommandCollection>
    {
        public ImportCustomerCommandValidation()
        {
            RuleFor(x => x.Customers)
                .NotNull()
                .WithMessage("Customers is null!");

            RuleFor(x => x.Customers.Count())
                .GreaterThan(0)
                .WithMessage("There is no customer to import!");

            RuleForEach(x => x.Customers)
                .Must(f => !f.Forename.Equals(string.Empty))
                .WithMessage("Some customers has no forename!")
                .Must(s => !s.Surname.Equals(string.Empty))
                .WithMessage("Some customers has no surname!");
        }
    }
}
