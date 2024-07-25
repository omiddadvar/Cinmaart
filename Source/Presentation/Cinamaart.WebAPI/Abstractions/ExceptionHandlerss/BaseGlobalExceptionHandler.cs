using Cinamaart.Domain.Abstractions;
using Cinamaart.WebAPI.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlerss
{
    public class BaseGlobalExceptionHandler(Exception ex) : IGlobalExceptionHandler
    {
        public virtual Result<object> ProcessException()
        {
            return Result<object>.Failure(ex.ToStandardErrors());
        }
    }
}
