using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.TvSeries.Command.AddTvSerie
{
    internal class AddTvSerieCommandHandler(
            IMapper mapper,
            ITvSerieRepository tvSerieRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddTvSerieCommandHandler> logger
        ) : IRequestHandler<AddTvSerieCommand, Result<TvSerieDTO>>
    {
        public async Task<Result<TvSerieDTO>> Handle(AddTvSerieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TvSerie = mapper.Map<TvSerie>(request);
                TvSerie = await tvSerieRepository.AddAsync(TvSerie);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<TvSerieDTO>(TvSerie);
                return Result<TvSerieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding TvSerie, requested data = {request}", request.ToJson());
                return Result<TvSerieDTO>.Failure("AddTvSerie.Exception", ex.Message);
            }
        }
    }
}
