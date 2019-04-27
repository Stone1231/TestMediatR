using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestMediatR
{
    public class LogPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LogPostProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, TResponse response)
        {
            _logger.LogInformation($"{nameof(LogPostProcessor<TRequest, TRequest>)} Request -- {JsonConvert.SerializeObject(request)}");

            _logger.LogInformation($"{nameof(LogPostProcessor<TRequest, TResponse>)} Response -- {JsonConvert.SerializeObject(response)}");

            return Task.CompletedTask;
        }
    }
}