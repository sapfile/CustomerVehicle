using FluentValidation;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles
{
    public class GetAllVehiclesQueryValidation : AbstractValidator<GetAllVehiclesQuery>
    {
        public GetAllVehiclesQueryValidation()
        {
            RuleFor(x => x.ReportType)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Report type has to set as parameter!");
        }
    }
}
