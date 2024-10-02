using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Authors.Queries.GetPaginatedAuthor
{
    public class GetPaginatedAuthorQuery : PaginationDTO, IRequest<WebServiceResult<PagedList<AuthorDTO>>>
    {
        public string NameSearchKeyword { get; set; }
    }
}
