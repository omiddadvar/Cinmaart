using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Queries.GetPaginatedArtists
{
    public class GetPaginatedArtistsQuery : PaginationDTO, IRequest<WebServiceResult<PagedList<GetArtistDTO>>>
    {
        public string NameSearchKeyword { get; set; }
        public List<int>? Countries { get; set; }
    }
}
