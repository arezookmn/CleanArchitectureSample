using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Common.PipelineBehaviors;
public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
: IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation(" Request: {@Request}",
             request);

        var response = await next();

        _logger.LogInformation(" Response: {requestName} {@Response}", requestName, response);
        return response;
    }
}
