using Cinamaart.Domain.Abstractions;

namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlers
{
    public interface IGlobalExceptionHandler
    {
        Result<object> ProcessException();
    }
}
