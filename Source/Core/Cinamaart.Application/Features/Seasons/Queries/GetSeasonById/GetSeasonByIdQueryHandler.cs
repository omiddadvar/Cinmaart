using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Seasons;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Seasons.Queries.GetSeasonById
{
    internal class GetSeasonByIdQueryHandler(
        IMapper mapper,
        ISeasonRepository SeasonRepository,
        ILogger<GetSeasonByIdQueryHandler> logger
    ) : IRequestHandler<GetSeasonByIdQuery, WebServiceResult<SeasonDTO>>
    {
        public async Task<WebServiceResult<SeasonDTO>> Handle(GetSeasonByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await SeasonRepository.GetAsync(request.SeasonId, cancellationToken);
                var data = mapper.Map<SeasonDTO>(artist);
                return WebServiceResult<SeasonDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading Season data, Seasonid = {Seasonid}", request.SeasonId);
                return WebServiceResult<SeasonDTO>.Failure("GetSeasonById.Exception", ex.Message);
            }
        }
    }
}
