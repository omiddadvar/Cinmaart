using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Movies.Queries.GetAllMovies
{
    internal class GetAllMoviesQueryHandler(
            IMapper mapper,
            IMovieRepository movieRepository,
            ILogger<GetAllMoviesQueryHandler> logger
        ) : IRequestHandler<GetAllMoviesQuery, WebServiceResult<IList<MovieDTO>>>
    {
        public async Task<WebServiceResult<IList<MovieDTO>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await movieRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken,
                    a => a.Country);

                var data = mapper.Map<IList<MovieDTO>>(rawData.ToArray());
                return WebServiceResult<IList<MovieDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all movies data");
                return WebServiceResult<IList<MovieDTO>>.Failure("GetAllMovies.Exception", ex.Message);
            }
        }
    }
}
