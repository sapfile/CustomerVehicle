using CustomerVehicle.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Behaviours
{
    public class GeneralException<TReq, TRes> : IPipelineBehavior<TReq, TRes>
    {
        private readonly ILogger<TReq> _logger;
        private readonly IDateTime _dateTime;

        public GeneralException(
            ILogger<TReq> logger, 
            IDateTime dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Request: {typeof(TReq).Name} got exception error at {_dateTime.Now}, " +
                                   $"Error message is: {ex.Message}, Please take a look!");

                throw;
            }
        }
    }
}
