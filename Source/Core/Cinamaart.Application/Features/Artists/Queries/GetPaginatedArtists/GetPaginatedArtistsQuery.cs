using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Queries.GetPaginatedArtists
{
    public class GetPaginatedArtistsQuery : PaginationDTO , IRequest<Result<PagedList<GetArtistDTO>>>
    {
        public string NameSearchKeyword {  get; set; }
        public List<int>? Countries {  get; set; }
    }
}
