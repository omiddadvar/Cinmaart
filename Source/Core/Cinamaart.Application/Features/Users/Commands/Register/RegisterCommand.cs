using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    public record RegisterCommand(
        string Username,
        string Email,
        string ConfirmEmail,
        string Password,
        string ConfirmPassword,
        string? PhoneNumber,
        string? FirstName,
        string? LastName
    ) : IRequest<WebServiceResult<long?>>;
}
