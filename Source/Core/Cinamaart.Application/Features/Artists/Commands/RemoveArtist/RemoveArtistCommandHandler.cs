using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Commands.AddArtist;
using Cinamaart.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Artists.Commands.RemoveArtist
{
    public class RemoveArtistCommandHandler(
        IArtistRepository artistRepository,
        IUnitOfWork unitOfWork,
        ILogger<AddArtistCommandHandler> logger
        ) : IRequestHandler<RemoveArtistCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveArtistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await artistRepository.DeleteAsync(request.ArtistId);
                await unitOfWork.SaveAsync(cancellationToken);
                return WebServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing artist, artistId = {ArtistId}", request.ArtistId);
                return WebServiceResult<bool>.Failure("RemoveArtist.Exception", ex.Message);
            }
        }
    }
}
