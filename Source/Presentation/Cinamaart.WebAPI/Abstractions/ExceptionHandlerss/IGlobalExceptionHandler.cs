using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlerss
{
    public interface IGlobalExceptionHandler
    {
        Result<object> ProcessException();
    }
}
