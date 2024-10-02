using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries.GetAllArtists;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Genres.Queries.GetGenreById
{
    internal class GetGenreByIdQueryHandler(
            IMapper mapper,
            IArtistRepository artistRepository,
            ILogger<GetAllArtistsQueryHandler> logger)
        : IRequestHandler<GetGenreByIdQuery, Result<GenreDTO>>
    {
        public async Task<Result<GenreDTO>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var genre = await artistRepository.GetAsync(request.Id, cancellationToken);
                var data = mapper.Map<GenreDTO>(genre);
                return Result<GenreDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading genre data, genreid = {genre}", request.Id);
                return Result<GenreDTO>.Failure("GetGenreById.Exception", ex.Message);
            }
        }
    }
}
