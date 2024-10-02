using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Movies.Queries.GetMovieById
{
    internal class GetMovieByIdQueryHandler(
        IMapper mapper,
        IMovieRepository movieRepository,
        ILogger<GetMovieByIdQueryHandler> logger
    ) : IRequestHandler<GetMovieByIdQuery, Result<MovieDTO>>
    {
        public async Task<Result<MovieDTO>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await movieRepository.GetAsync(request.MovieId, cancellationToken);
                var data = mapper.Map<MovieDTO>(artist);
                return Result<MovieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading movie data, movieid = {movieid}", request.MovieId);
                return Result<MovieDTO>.Failure("GetMovieById.Exception", ex.Message);
            }
        }
    }
}
