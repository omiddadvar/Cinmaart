using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetAllTvSeries
{
    public record GetAllTvSeriesQuery : IRequest<Result<IList<TvSerieDTO>>>;
}
