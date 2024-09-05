using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Episodes.Commands.AddEpisode
{
    public record AddEpisodeCommand(
            string Name,
            string Description,
            int SeasonId
        ) : IRequest<Result<EpisodeDTO>>;
}
