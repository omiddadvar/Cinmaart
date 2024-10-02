﻿using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Seasons.Commands.RemoveSeason
{
    public record RemoveSeasonCommand(int SeasonId) : IRequest<Result<bool>>;
}
