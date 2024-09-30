using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Queries.GetArtistById
{
    public class GetArtistQueryHandler(
        IMapper mapper,
        IArtistRepository artistRepository,
        ILogger<GetArtistQueryHandler> logger
    ) : IRequestHandler<GetArtistQuery, WebServiceResult<GetArtistDTO>>
    {
        public async Task<WebServiceResult<GetArtistDTO>> Handle(GetArtistQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await artistRepository.GetAsync(request.ArtistId, cancellationToken);
                var data = mapper.Map<GetArtistDTO>(artist);
                return WebServiceResult<GetArtistDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex , "Error while reading artist data, artistid = {ArtistId}", request.ArtistId);
                return WebServiceResult<GetArtistDTO>.Failure("GetArtist.Exception", ex.Message);
            }
        }
    }
}
