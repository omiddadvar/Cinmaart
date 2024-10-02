using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Seasons.Commands.RemoveSeason
{
    internal class RemoveSeasonCommandHandler(
            ISeasonRepository SeasonRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveSeasonCommandHandler> logger
        ) : IRequestHandler<RemoveSeasonCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveSeasonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await SeasonRepository.DeleteAsync(request.SeasonId);
                await unitOfWork.SaveAsync(cancellationToken);
                return WebServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing Season, SeasonId = {SeasonId}", request.SeasonId);
                return WebServiceResult<bool>.Failure("RemoveSeason.Exception", ex.Message);
            }
        }
    }
}
