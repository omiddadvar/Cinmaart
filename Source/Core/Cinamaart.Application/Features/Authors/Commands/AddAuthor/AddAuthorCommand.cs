using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authors.Commands.AddAuthor
{
    public record AddAuthorCommand(
            string Name,
            string? Description,
            long UserId
        ) : IRequest<WebServiceResult<AuthorDTO>>;
}
