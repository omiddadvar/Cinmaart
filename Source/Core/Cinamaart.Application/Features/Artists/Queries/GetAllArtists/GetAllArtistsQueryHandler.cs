using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Commands.UpdateArtist;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Artists.Queries.GetAllArtists
{
    public class GetAllArtistsQueryHandler(
            IMapper mapper,
            IArtistRepository artistRepository,
            ILogger<GetAllArtistsQueryHandler> logger) :
        IRequestHandler<GetAllArtistsQuery, Result<List<GetArtistDTO>>>
    {
        public async Task<Result<List<GetArtistDTO>>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await artistRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.FullName),
                    cancellationToken,
                    a => a.Country, e => e.Gender);

                var data = mapper.Map<List<GetArtistDTO>>(rawData.ToList());
                return Result<List<GetArtistDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all artist data");
                return Result<List<GetArtistDTO>>.Failure("GetAllArtists.Exception", ex.Message);
            }
        }
    }
}
