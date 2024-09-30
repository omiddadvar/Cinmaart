using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authentication.Commands.ConfirmEmail
{
    public record ConfirmEmailCommand(
        long UserId,
        string Token
        ) : IRequest<WebServiceResult<bool>>;
}
