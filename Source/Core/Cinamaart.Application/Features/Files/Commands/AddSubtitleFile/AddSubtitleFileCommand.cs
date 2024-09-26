using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Files.Commands.AddSubtitleFile
{

    public record AddSubtitleFileCommand(
        IFormFile File,
        long Subtitle) : IRequest<Result<string>>;
}
