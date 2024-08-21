using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Cinamaart.Application.Features.Genres.Queries.GetAllGeners
{
    internal class GetAllGenersQueryHandler(
            IMapper mapper,
            IGenreRepository genreRepository,
            ILogger<GetAllGenersQueryHandler> logger
        )
        : IRequestHandler<GetAllGenersQuery, Result<IList<GenreDTO>>>
    {
        public async Task<Result<IList<GenreDTO>>> Handle(GetAllGenersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await genreRepository.GetAsync(
                   Where: null,
                   a => a.OrderBy(e => e.Name),
                   cancellationToken);

                var data = mapper.Map<List<GenreDTO>>(rawData.ToList());
                return Result<IList<GenreDTO>>.Success(data);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while reading all genre data");
                return Result<IList<GenreDTO>>.Failure("GetAllGeners.Exception", ex.Message);
            }
        }
    }
}
