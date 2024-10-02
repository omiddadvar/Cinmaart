using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Movies.Queries.GetPaginatedMovies
{
    internal class GetPaginatedMoviesQueryHandler(
            IMapper mapper,
            IMovieRepository movieRepository,
            ILogger<GetPaginatedMoviesQueryHandler> logger
        ) : IRequestHandler<GetPaginatedMoviesQuery, WebServiceResult<PagedList<MovieDTO>>>
    {
        public async Task<WebServiceResult<PagedList<MovieDTO>>> Handle(GetPaginatedMoviesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Movie, bool>> Where =
                    m => (string.IsNullOrWhiteSpace(request.NameSearchKeyword) || m.Name.Contains(request.NameSearchKeyword))
                    && (
                        (request.ExactYear != null && m.Year == request.ExactYear)
                        || (request.ExactYear == null &&
                            (
                                (request.YearLowerBound == null || m.Year >= request.YearLowerBound)
                                && (request.YearUpperBound == null || m.Year <= request.YearUpperBound)
                            )
                    ))
                    && (request.Countries == null || request.Countries.Contains(m.CountryId.Value));

                var rawData = await movieRepository.PaginateAsync(
                    page: request.Page,
                    pageSize: request.PageSize,
                    Where : Where,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    e => e.Country);

                var data = mapper.Map<PagedList<Movie>, PagedList<MovieDTO>>(rawData);
                return WebServiceResult<PagedList<MovieDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading paginated movie data, requested data = {request}", request.ToJson());
                return WebServiceResult<PagedList<MovieDTO>>.Failure("GetPaginatedMovies.Exception", ex.Message);
            }
        }
    }
}
