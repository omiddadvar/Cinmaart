using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Queries.GetPaginatedAuthor
{
    public class GetPaginatedAuthorQuery : PaginationDTO, IRequest<Result<PagedList<AuthorDTO>>>
    {
        public string NameSearchKeyword { get; set; }
    }
}
