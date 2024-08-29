using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Tags.Commands.RemoveTag
{
    public record RemoveTagCommand(int Id) : IRequest<Result<bool>>;
}
