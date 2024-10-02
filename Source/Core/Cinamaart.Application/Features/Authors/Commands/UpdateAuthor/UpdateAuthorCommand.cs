using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authors.Commands.UpdateAuthor
{
    internal class UpdateAuthorCommand(
        int Id,
        string Name,
        string? Description
        ) : IRequest<WebServiceResult<AuthorDTO>>;
}
