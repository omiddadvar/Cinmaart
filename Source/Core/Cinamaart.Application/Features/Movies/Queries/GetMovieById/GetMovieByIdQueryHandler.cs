using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Features.Movies.Queries.GetAllMovies;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Movies.Queries.GetMovieById
{
    internal class GetMovieByIdQueryHandler(
        IMapper mapper,
        IMovieRepository movieRepository,
        ILogger<GetMovieByIdQueryHandler> logger
    ) : IRequestHandler<GetMovieByIdQuery, WebServiceResult<MovieDTO>>
    {
        public async Task<WebServiceResult<MovieDTO>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await movieRepository.GetAsync(request.MovieId, cancellationToken);
                var data = mapper.Map<MovieDTO>(artist);
                return WebServiceResult<MovieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading movie data, movieid = {movieid}", request.MovieId);
                return WebServiceResult<MovieDTO>.Failure("GetMovieById.Exception", ex.Message);
            }
        }
    }
}
