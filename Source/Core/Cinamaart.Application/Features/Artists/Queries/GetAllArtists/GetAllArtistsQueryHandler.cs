using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Artists.Queries.GetAllArtists
{
    public class GetAllArtistsQueryHandler(
            IMapper mapper,
            IArtistRepository artistRepository) :
        IRequestHandler<GetAllArtistsQuery, Result>
    {
        public async Task<Result> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await artistRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.FullName),
                    cancellationToken,
                    a => a.Country, e => e.Gender);

                var data = mapper.Map<List<GetAllArtistsDTO>>(rawData.ToList());
                return Result.Success(data);
            }
            catch (Exception ex)
            {
                return Result.Failure("GetAllArtists.Exception", ex.Message);
            }
        }
    }
}
