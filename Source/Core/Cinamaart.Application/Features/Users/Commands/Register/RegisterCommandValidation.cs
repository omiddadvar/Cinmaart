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
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage(_localizer["ObligatoryValue","Username"]);
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage(_localizer["ObligatoryValue", "Password"]);
            RuleFor(x => x.ConfirmEmail).NotNull().NotEmpty().WithMessage(_localizer["ObligatoryValue", "ConfirmEmail"]);
            RuleFor(x => x.Password).Equal(x => x.ConfirmEmail).WithMessage(_localizer["ConfirmPasswordNotValid???"]);
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(_localizer["ObligatoryValue","Email"]);
            RuleFor(x => x.ConfirmEmail).NotNull().NotEmpty().WithMessage(_localizer["ObligatoryValue", "ConfirmEmail"]);
            RuleFor(x => x.Email).Equal(x => x.ConfirmEmail).WithMessage(_localizer["ConfirmEmailNotValid"]);
        }
    }
}
