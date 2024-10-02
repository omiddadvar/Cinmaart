using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Cinamaart.Application.Extentions
{
    public static class IdentityResultExtensions
    {
        public static WebServiceResult<T> ToStandardWebServiceResult<T>(this IdentityResult identityResult)
        {
            var result = new WebServiceResult<T>(
                StatusCodes.Status400BadRequest,
                identityResult.Succeeded,
                typeof(T) == typeof(bool) ? (T)(object)identityResult.Succeeded : default(T),
                identityResult.Errors.ToErrors()
                );
            return result;
        }
    }
}
