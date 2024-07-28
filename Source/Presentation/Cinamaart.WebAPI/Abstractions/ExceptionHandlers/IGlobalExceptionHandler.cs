using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlers
{
    public interface IGlobalExceptionHandler
    {
        Result<object> ProcessException();
    }
}
