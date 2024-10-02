using Cinamaart.Application.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authors.Queries.GetAllAuthors
{
    public record GetAllAuthorsQuery : IRequest<WebServiceResult<IList<AuthorDTO>>>;
}
