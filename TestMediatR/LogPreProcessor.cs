using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestMediatR
{
    public class LogPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;

        public LogPreProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(LogPreProcessor<TRequest>)} Request -- {JsonConvert.SerializeObject(request)}");

            return Task.CompletedTask;
        }
    }
}