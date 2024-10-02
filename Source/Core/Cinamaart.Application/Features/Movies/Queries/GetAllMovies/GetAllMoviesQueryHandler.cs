using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Movies.Queries.GetAllMovies
{
    internal class GetAllMoviesQueryHandler(
            IMapper mapper,
            IMovieRepository movieRepository,
            ILogger<GetAllMoviesQueryHandler> logger
        ) : IRequestHandler<GetAllMoviesQuery, Result<IList<MovieDTO>>>
    {
        public async Task<Result<IList<MovieDTO>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await movieRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.Country);

                var data = mapper.Map<IList<MovieDTO>>(rawData.ToArray());
                return Result<IList<MovieDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all movies data");
                return Result<IList<MovieDTO>>.Failure("GetAllMovies.Exception", ex.Message);
            }
        }
    }
}
