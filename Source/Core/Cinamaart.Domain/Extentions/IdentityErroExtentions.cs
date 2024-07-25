using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Extentions
{
    public static class IdentityErroExtentions
    {
        public static Error? ToError(this IdentityError identityError)
        {
            if (identityError is null) return null;
            return new Error(identityError.Code, identityError.Description);
        }
        public static Error[]? ToErrors(this IEnumerable<IdentityError> identityErrors)
        {
            if (identityErrors is null) return null;
            IdentityError[] identityErrorArray = identityErrors.ToArray();
            if (identityErrorArray.Length.Equals(0)) return new Error[0];

            var errorArray = new Error[identityErrorArray.Length];
            for(int i = 0; i < identityErrorArray.Length; i++)
            {
                var identityError = identityErrorArray[i];
                errorArray[i] = new Error(identityError.Code, identityError.Description);
            }
            return errorArray;
        }
    }
}
