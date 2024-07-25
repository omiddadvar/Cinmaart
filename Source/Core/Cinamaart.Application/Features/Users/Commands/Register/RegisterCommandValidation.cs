using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    internal class RegisterCommandValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidation(IStringLocalizer<StringResources> _localizer)
        {
            string frfrfr = _localizer[LocalStringKeyword.ConfirmPasswordNotValid].Value;
            string aaaaaaa = _localizer[LocalStringKeyword.ObligatoryValue, "Username"];
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage(_localizer[LocalStringKeyword.ObligatoryValue,"Username"]);
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage(_localizer[LocalStringKeyword.ObligatoryValue, "Password"]);
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().WithMessage(_localizer[LocalStringKeyword.ObligatoryValue, "ConfirmPassword"]);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage(_localizer[LocalStringKeyword.ConfirmPasswordNotValid]);
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(_localizer[LocalStringKeyword.ObligatoryValue, "Email"]);
            RuleFor(x => x.ConfirmEmail).NotNull().NotEmpty().WithMessage(_localizer[LocalStringKeyword.ObligatoryValue, "ConfirmEmail"]);
            RuleFor(x => x.Email).Equal(x => x.ConfirmEmail).WithMessage(_localizer[LocalStringKeyword.ConfirmEmailNotValid]);
        }
    }
}
