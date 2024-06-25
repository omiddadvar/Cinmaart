using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Queries.GetAllArtists
{
    public class GetAllArtistsQueryHandler(
            IMapper mapper, 
            IArtistRepository artistRepository) :
        IRequestHandler<GetAllArtistsQuery, List<GetAllArtistsDTO>>
    {
        public async Task<List<GetAllArtistsDTO>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            var data = await artistRepository.GetAsync(
                Where: null,
                a => a.OrderBy(e => e.FullName),
                cancellationToken,
                a => a.Country, e => e.Gender);

            return mapper.Map<List<GetAllArtistsDTO>>(data.ToList());

        }
    }
}
