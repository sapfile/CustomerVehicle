using CustomerVehicle.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Behaviours
{
    public class Performance<TReq, TRes> : IPipelineBehavior<TReq, TRes>
    {
        private readonly ILogger<TReq> _logger;
        private readonly IDateTime _dateTime;
        private readonly Stopwatch _stopwatch;

        public Performance(
            ILogger<TReq> logger, 
            IDateTime dateTime,
            Stopwatch stopwatch)
        {
            _logger = logger;
            _dateTime = dateTime;
            _stopwatch = stopwatch;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next)
        {
            _stopwatch.Start();

            var resp = await next();

            _stopwatch.Stop();

            if (_stopwatch.ElapsedMilliseconds > 1000)
            {
                _logger.LogWarning($"Request: {typeof(TReq).Name} took longer than 1 second at {_dateTime.Now}, Please attention!");
            }

            return resp;
        }
    }
}
