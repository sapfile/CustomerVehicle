using CustomerVehicle.Infrastructure.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Behaviours
{
    public class Logging<TReq> : IRequestPreProcessor<TReq>
    {
        private readonly ILogger<TReq> _logger;
        private readonly IDateTime _dateTime;

        public Logging(
            ILogger<TReq> logger,
            IDateTime dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public async Task Process(TReq request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(TReq).Name} has requested! at {_dateTime.Now}");
        }
    }
}
