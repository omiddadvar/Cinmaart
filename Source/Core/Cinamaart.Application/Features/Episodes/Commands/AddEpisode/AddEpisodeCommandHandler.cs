using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
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

namespace Cinamaart.Application.Features.Episodes.Commands.AddEpisode
{
    internal class AddEpisodeCommandHandler(
            IMapper mapper,
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddEpisodeCommandHandler> logger
        ) : IRequestHandler<AddEpisodeCommand, Result<EpisodeDTO>>
    {
        public async Task<Result<EpisodeDTO>> Handle(AddEpisodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Episode = mapper.Map<Episode>(request);
                Episode = await episodeRepository.AddAsync(Episode);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<EpisodeDTO>(Episode);
                return Result<EpisodeDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding Episode, requested data = {request}", request.ToJson());
                return Result<EpisodeDTO>.Failure("AddEpisode.Exception", ex.Message);
            }
        }
    }
}
