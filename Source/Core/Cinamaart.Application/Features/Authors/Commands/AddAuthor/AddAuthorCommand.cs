using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Commands.AddAuthor
{
    public record AddAuthorCommand(
            string Name,
            string? Description,
            long UserId
        ) : IRequest<WebServiceResult<AuthorDTO>>;
}
