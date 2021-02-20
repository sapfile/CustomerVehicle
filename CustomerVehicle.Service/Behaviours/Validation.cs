using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Behaviours
{
    public class Validation<TReq, TRes> : IPipelineBehavior<TReq, TRes>
    {
        private readonly IEnumerable<IValidator<TReq>> _validators;

        public Validation(
            IEnumerable<IValidator<TReq>> validators)
        {
            _validators = validators;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            var anyValidation = _validators.Any();

            if (anyValidation)
            {
                var context = new ValidationContext(request);

                var validations = _validators.Select(v => v.ValidateAsync(context, cancellationToken));

                var validationResults = await Task.WhenAll(validations);

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count > 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
