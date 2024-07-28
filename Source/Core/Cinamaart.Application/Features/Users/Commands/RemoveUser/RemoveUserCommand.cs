using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Commands.RemoveUser
{
    public record RemoveUserCommand(long UserId) : IRequest<Result<bool>>;
}
