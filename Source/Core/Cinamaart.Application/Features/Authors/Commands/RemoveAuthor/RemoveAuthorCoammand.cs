using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authors.Commands.RemoveAuthor
{
    public record RemoveAuthorCoammand(int AuthorId) : IRequest<WebServiceResult<bool>>;
}
