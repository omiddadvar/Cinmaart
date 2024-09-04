using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.TvSeries.Command.RemoveTvSerie
{
    internal class RemoveTvSerieCommandHandler(
            ITvSerieRepository tvSerieRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveTvSerieCommandHandler> logger
        ) : IRequestHandler<RemoveTvSerieCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveTvSerieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await tvSerieRepository.DeleteAsync(request.TvSerieId);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing TvSerie, TvSerieId = {TvSerieId}", request.TvSerieId);
                return Result<bool>.Failure("RemoveTvSerie.Exception", ex.Message);
            }
        }
    }
}
