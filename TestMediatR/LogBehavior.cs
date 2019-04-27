using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestMediatR
{
    public class LogBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LogBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"LogBehavior Request -- {JsonConvert.SerializeObject(request)}");
            
            var response = await next();
            
            _logger.LogInformation($"LogBehavior Response -- {JsonConvert.SerializeObject(response)}");
            
            return response;
        }
    }
}