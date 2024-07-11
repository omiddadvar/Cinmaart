using AutoMapper;
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

namespace Cinamaart.Application.Features.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandHandler(
        IMapper mapper,
        IArtistRepository artistRepository,
        IUnitOfWork unitOfWork,
        ILogger<UpdateArtistCommandHandler> logger
        ) : IRequestHandler<UpdateArtistCommand, Result<GetArtistDTO>>
    {
        public async Task<Result<GetArtistDTO>> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = mapper.Map<Artist>(request);
                await artistRepository.UpdateAsync(artist);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<GetArtistDTO>(artist);
                return Result<GetArtistDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while editing artist, requested data = {request}", request.ToJson());
                return Result<GetArtistDTO>.Failure("UpdateArtist.Exception", ex.Message);
            }
        }
    }
}
