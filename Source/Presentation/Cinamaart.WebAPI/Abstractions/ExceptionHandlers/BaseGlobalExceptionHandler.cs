using Cinamaart.Domain.Abstractions;
using Cinamaart.WebAPI.Extentions;
using FluentValidation;

namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlers
{
    public class BaseGlobalExceptionHandler(Exception ex) : IGlobalExceptionHandler
    {
        public virtual Result<object> ProcessException()
        {
            Type type = ex.GetType();
            switch (ex)
            {
                case ValidationException validationException:
                    return Result<object>.Failure(validationException.ToStandardErrors());
                default:
                    return Result<object>.Failure(ex.ToStandardErrors());
            }
        }
    }
}
