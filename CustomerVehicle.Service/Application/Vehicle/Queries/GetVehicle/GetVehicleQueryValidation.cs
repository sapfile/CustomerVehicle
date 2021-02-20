using CustomerVehicle.Service.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle
{
    public class GetVehicleQueryValidation : AbstractValidator<GetVehicleQuery>
    {
        public GetVehicleQueryValidation(
            IServiceScopeFactory scopeFactory)
        {
            RuleFor(x => x.VehicleId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("VehicleID has to be greather than 0!")
                .MustAsync(async (q, cancellationtoken) =>
                {
                    using (var scope = scopeFactory.CreateScope())
                    {
                        var dataValidationService = scope.ServiceProvider.GetRequiredService<IDataValidationService>();

                        var exsits = await dataValidationService.IsVehicleExists(q, cancellationtoken);

                        return exsits;
                    }
                })
                .WithMessage("Vehicle couldnt find!");
        }
    }
}
