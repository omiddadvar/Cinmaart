﻿using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Roles.Commands.AddRoleToUser
{
    public record AddRoleToUserCommand(long UserId , IList<string> Roles)
        : IRequest<WebServiceResult<bool>>;
}
