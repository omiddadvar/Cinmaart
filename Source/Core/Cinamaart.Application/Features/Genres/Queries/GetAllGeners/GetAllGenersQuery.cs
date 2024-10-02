using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Genres.Queries.GetAllGeners
{
    public record GetAllGenersQuery : IRequest<WebServiceResult<IList<GenreDTO>>>;
}
