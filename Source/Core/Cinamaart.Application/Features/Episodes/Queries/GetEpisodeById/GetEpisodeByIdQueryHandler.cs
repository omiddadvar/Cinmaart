using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Episodes;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Episodes.Queries.GetEpisodeById
{
    internal class GetEpisodeByIdQueryHandler(
        IMapper mapper,
        IEpisodeRepository episodeRepository,
        ILogger<GetEpisodeByIdQueryHandler> logger
    ) : IRequestHandler<GetEpisodeByIdQuery, Result<EpisodeDTO>>
    {
        public async Task<Result<EpisodeDTO>> Handle(GetEpisodeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await episodeRepository.GetAsync(request.EpisodeId, cancellationToken);
                var data = mapper.Map<EpisodeDTO>(artist);
                return Result<EpisodeDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading Episode data, Episodeid = {Episodeid}", request.EpisodeId);
                return Result<EpisodeDTO>.Failure("GetEpisodeById.Exception", ex.Message);
            }
        }
    }
}
