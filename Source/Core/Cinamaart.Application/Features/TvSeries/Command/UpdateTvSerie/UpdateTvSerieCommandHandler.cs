using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.TvSeries.Command.UpdateTvSerie
{
    internal class UpdateTvSerieCommandHandler(
            IMapper mapper,
            ITvSerieRepository tvSerieRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateTvSerieCommandHandler> logger
        ) : IRequestHandler<UpdateTvSerieCommand, Result<TvSerieDTO>>
    {
        public async Task<Result<TvSerieDTO>> Handle(UpdateTvSerieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TvSerie = mapper.Map<TvSerie>(request);
                await tvSerieRepository.UpdateAsync(TvSerie);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<TvSerieDTO>(TvSerie);
                return Result<TvSerieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while updating TvSerie, requested data = {request}", request.ToJson());
                return Result<TvSerieDTO>.Failure("UpdateTvSerie.Exception", ex.Message);
            }
        }
    }
}
