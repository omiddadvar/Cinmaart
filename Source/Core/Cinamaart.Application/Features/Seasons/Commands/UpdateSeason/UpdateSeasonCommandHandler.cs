using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Seasons.Commands.UpdateSeason
{
    internal class UpdateSeasonCommandHandler(
            IMapper mapper,
            ISeasonRepository SeasonRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateSeasonCommandHandler> logger
        ) : IRequestHandler<UpdateSeasonCommand, Result<SeasonDTO>>
    {
        public async Task<Result<SeasonDTO>> Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Season = mapper.Map<Season>(request);
                await SeasonRepository.UpdateAsync(Season);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<SeasonDTO>(Season);
                return Result<SeasonDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while updating Season, requested data = {request}", request.ToJson());
                return Result<SeasonDTO>.Failure("UpdateSeason.Exception", ex.Message);
            }
        }
    }
}
