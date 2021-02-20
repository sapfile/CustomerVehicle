using CustomerVehicle.Service.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerVehicle.Service.Application.Vehicle.Command.UpdateVehicle
{
    public class UpdateVehicleCommandValidation : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidation(
            IServiceScopeFactory scopeFactory)
        {
            RuleFor(x => x)
                .MustAsync(async (cmd, cancellationtoken) =>
                {
                    using (var scope = scopeFactory.CreateScope())
                    {
                        var dataValidationService = scope.ServiceProvider.GetRequiredService<IDataValidationService>();

                        var exsits = await dataValidationService.IsRegNumberHasOtherVehicle(cmd.VehicleId, cmd.RegistrationNumber, cancellationtoken);

                        return !exsits;
                    }
                })
                .WithMessage("This number is already registred other car!");
        }
    }
}
