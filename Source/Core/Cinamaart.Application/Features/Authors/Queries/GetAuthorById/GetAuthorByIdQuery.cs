using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authors.Queries.GetAuthorById
{
    public record GetAuthorByIdQuery(int AuthorId) : IRequest<WebServiceResult<AuthorDTO>>;
}
