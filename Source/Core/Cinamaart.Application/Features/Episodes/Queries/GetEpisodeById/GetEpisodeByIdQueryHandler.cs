﻿using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Episodes.Queries.GetEpisodeById
{
    internal class GetEpisodeByIdQueryHandler(
        IMapper mapper,
        IEpisodeRepository episodeRepository,
        ILogger<GetEpisodeByIdQueryHandler> logger
    ) : IRequestHandler<GetEpisodeByIdQuery, WebServiceResult<EpisodeDTO>>
    {
        public async Task<WebServiceResult<EpisodeDTO>> Handle(GetEpisodeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await episodeRepository.GetAsync(request.EpisodeId, cancellationToken);
                var data = mapper.Map<EpisodeDTO>(artist);
                return WebServiceResult<EpisodeDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading Episode data, Episodeid = {Episodeid}", request.EpisodeId);
                return WebServiceResult<EpisodeDTO>.Failure("GetEpisodeById.Exception", ex.Message);
            }
        }
    }
}
