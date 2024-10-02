using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;


namespace Cinamaart.Application.Features.Movies.Queries.GetPaginatedMovies
{
    public class GetPaginatedMoviesQuery : PaginationDTO, IRequest<WebServiceResult<PagedList<MovieDTO>>>
    {
        public string? NameSearchKeyword { get; set; }
        public int? ExactYear { get; set; }
        public int? YearLowerBound { get; set; }
        public int? YearUpperBound {  get; set; }
        public List<int>? Countries { get; set; }
    }
}
