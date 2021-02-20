using FluentValidation;

namespace CustomerVehicle.Service.Application.Customer.Commands.ConvertFromCSV
{
    public class ConvertFromCSVCommandValidation : AbstractValidator<ConvertFromCSVCommand>
    {
        public ConvertFromCSVCommandValidation()
        {
            RuleFor(x => x.FileName)
                .NotEmpty()
                .WithMessage("Filename cannot be empty!")
                .Must(fn => fn.EndsWith(".csv"))
                .WithMessage("File must be csv!");

            RuleFor(x => x.FileStream)
                .NotNull()
                .WithMessage("File cannot be null!");
        }
    }
}
