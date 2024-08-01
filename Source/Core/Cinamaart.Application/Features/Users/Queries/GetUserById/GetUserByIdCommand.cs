using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdCommand(long UserId) : IRequest<Result<UserDTO>>;
}
