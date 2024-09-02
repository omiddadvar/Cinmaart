using Cinamaart.Domain.Abstractions;
using MediatR;


namespace Cinamaart.Application.Features.Movies.Queries.GetPaginatedMovies
{
    internal class GetPaginatedMoviesQuery : PaginationDTO, IRequest<Result<PagedList<MovieDTO>>>
    {
        public string? NameSearchKeyword { get; set; }
        public int? ExactYear { get; set; }
        public int? YearLowerBound { get; set; }
        public int? YearUpperBound {  get; set; }
        public List<int>? Countries { get; set; }
    }
}
