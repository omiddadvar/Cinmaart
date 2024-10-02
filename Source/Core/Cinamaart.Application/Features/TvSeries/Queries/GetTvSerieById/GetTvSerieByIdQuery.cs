using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.TvSeries.Queries.GetTvSerieById
{
    public record GetTvSerieByIdQuery(int TvSerieId) : IRequest<WebServiceResult<TvSerieDTO>>;

}
