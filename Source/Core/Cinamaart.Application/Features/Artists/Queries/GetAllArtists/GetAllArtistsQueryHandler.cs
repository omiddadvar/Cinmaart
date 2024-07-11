using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Queries.GetAllArtists
{
    public class GetAllArtistsQueryHandler(
            IMapper mapper,
            IArtistRepository artistRepository) :
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
                return Result<List<GetArtistDTO>>.Failure("GetAllArtists.Exception", ex.Message);
            }
        }
    }
}
