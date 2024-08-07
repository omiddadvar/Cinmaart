﻿using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Commands.AddArtist;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Commands.RemoveArtist
{
    public class RemoveArtistCommandHandler (
        IArtistRepository artistRepository,
        IUnitOfWork unitOfWork,
        ILogger<AddArtistCommandHandler> logger
        ) : IRequestHandler<RemoveArtistCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveArtistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await artistRepository.DeleteAsync(request.ArtistId);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing artist, artistId = {ArtistId}", request.ArtistId);
                return Result<bool>.Failure("RemoveArtist.Exception", ex.Message);
            }
        }
    }
}
