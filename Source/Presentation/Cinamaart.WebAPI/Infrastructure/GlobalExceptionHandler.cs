using Cinamaart.Domain.Abstractions;
using Cinamaart.WebAPI.Abstractions;
using Cinamaart.WebAPI.Abstractions.ExceptionHandlerss;
using Microsoft.AspNetCore.Diagnostics;

namespace Cinamaart.WebAPI.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occured : {Message}", exception.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            var eceptionHandler = GlobalErrorHandlerFactory.CreateHandler(exception);
            var result = eceptionHandler.ProcessException();

            await httpContext.Response.WriteAsJsonAsync(result);
            return true;
        }
    }
}
