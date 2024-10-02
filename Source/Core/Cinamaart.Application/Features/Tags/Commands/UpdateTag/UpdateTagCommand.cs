using Cinamaart.Application.Abstractions;
using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Tags.Commands.UpdateTag
{
    public record UpdateTagCommand (
            int Id,
            string Name
        ) : IRequest<WebServiceResult<TagDTO>>;
}
