using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Seasons.Commands.AddSeason
{
    internal class AddSeasonCommandHandler(
            IMapper mapper,
            ISeasonRepository seasonRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddSeasonCommandHandler> logger
        ) : IRequestHandler<AddSeasonCommand, Result<SeasonDTO>>
    {
        public async Task<Result<SeasonDTO>> Handle(AddSeasonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Season = mapper.Map<Season>(request);
                Season = await seasonRepository.AddAsync(Season);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<SeasonDTO>(Season);
                return Result<SeasonDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding Season, requested data = {request}", request.ToJson());
                return Result<SeasonDTO>.Failure("AddSeason.Exception", ex.Message);
            }
        }
    }
}
