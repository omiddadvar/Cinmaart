using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetPaginatedTvSeries
{
    public class GetPaginatedTvSerieQuery : PaginationDTO, IRequest<Result<PagedList<TvSerieDTO>>>
    {
        public string? NameSearchKeyword { get; set; }
        public List<int>? Countries { get; set; }
    }
}
