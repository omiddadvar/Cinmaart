using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authentication.Queries.Login
{
    public record LoginCommand (
        string? Email,
        string? UserName,
        string Password
        ): IRequest<Result<LoginResultDTO>>;
}
