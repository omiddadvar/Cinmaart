using Cinamaart.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    public static class RegirterCommandErrors
    {
        public static Error EmailNotConfirmed = 
            new Error("Register.EmailNotConfirmed", "Email and ConfirmEmail values are not the same");
    }
}
