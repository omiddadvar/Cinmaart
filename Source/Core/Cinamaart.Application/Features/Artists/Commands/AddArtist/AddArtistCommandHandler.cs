using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Artists.Commands.AddArtist
{
    public class AddArtistCommandHandler(
        IMapper mapper,
        IArtistRepository artistRepository,
        IUnitOfWork unitOfWork,
        ILogger<AddArtistCommandHandler> logger
        ) : IRequestHandler<AddArtistCommand, WebServiceResult<GetArtistDTO>>
    {
        public async Task<WebServiceResult<GetArtistDTO>> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = mapper.Map<Artist>(request);
                artist = await artistRepository.AddAsync(artist);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<GetArtistDTO>(artist);
                return WebServiceResult<GetArtistDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding artist, requested data = {request}", request.ToJson());
                return WebServiceResult<GetArtistDTO>.Failure("AddArtist.Exception", ex.Message);
            }
        }
    }
}
