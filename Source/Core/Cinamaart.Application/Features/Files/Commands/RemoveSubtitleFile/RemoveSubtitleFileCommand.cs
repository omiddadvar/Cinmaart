﻿using Cinamaart.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Files.Commands.RemoveSubtitleFile
{
    public record RemoveSubtitleFileCommand(
            long SubtitleId
        ):IRequest<Result<bool>>;
}
