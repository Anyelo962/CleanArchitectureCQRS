using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    private readonly ILogger _logger;

    public UnhandledExceptionBehaviour(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();

        }
        catch (System.Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex,"Application request: Sucedio una excepcion para el request {Name} {@Request}", requestName, request);
            throw;
        }
    }
}