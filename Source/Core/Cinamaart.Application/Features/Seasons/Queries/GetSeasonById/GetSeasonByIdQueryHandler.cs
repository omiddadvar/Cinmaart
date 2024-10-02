using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Seasons.Queries.GetSeasonById
{
    internal class GetSeasonByIdQueryHandler(
        IMapper mapper,
        ISeasonRepository SeasonRepository,
        ILogger<GetSeasonByIdQueryHandler> logger
    ) : IRequestHandler<GetSeasonByIdQuery, Result<SeasonDTO>>
    {
        public async Task<Result<SeasonDTO>> Handle(GetSeasonByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await SeasonRepository.GetAsync(request.SeasonId, cancellationToken);
                var data = mapper.Map<SeasonDTO>(artist);
                return Result<SeasonDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading Season data, Seasonid = {Seasonid}", request.SeasonId);
                return Result<SeasonDTO>.Failure("GetSeasonById.Exception", ex.Message);
            }
        }
    }
}
