﻿using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.TvSeries.Command.AddTvSerie
{
    public record AddTvSerieCommand(
        string Name,
        string Description,
        int? CountryId
        ) : IRequest<WebServiceResult<TvSerieDTO>>;
}
