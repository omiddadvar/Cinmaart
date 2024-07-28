using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Extentions
{
    public static class IdentityResultExtensions
    {
        public static Result<T> ToStandardResult<T>(this IdentityResult identityResult)
        {
            var result = new Result<T>(
                identityResult.Succeeded,
                typeof(T) == typeof(bool) ? (T)(object)identityResult.Succeeded : default(T),
                identityResult.Errors.ToErrors()
                );
            return result;
        }
    }
}
