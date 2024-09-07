using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Commands.UpdateAuthor
{
    internal class UpdateAuthorCommand(
        int Id,
        string Name,
        string? Description
        ) : IRequest<Result<AuthorDTO>>;
}
