using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Seasons;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Seasons.Commands.UpdateSeason
{
    internal class UpdateSeasonCommandHandler(
            IMapper mapper,
            ISeasonRepository SeasonRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateSeasonCommandHandler> logger
        ) : IRequestHandler<UpdateSeasonCommand, WebServiceResult<SeasonDTO>>
    {
        public async Task<WebServiceResult<SeasonDTO>> Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Season = mapper.Map<Season>(request);
                await SeasonRepository.UpdateAsync(Season);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<SeasonDTO>(Season);
                return WebServiceResult<SeasonDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while updating Season, requested data = {request}", request.ToJson());
                return WebServiceResult<SeasonDTO>.Failure("UpdateSeason.Exception", ex.Message);
            }
        }
    }
}
