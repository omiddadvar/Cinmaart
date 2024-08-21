using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Genres.Commands.UpdateGenre
{
    internal class UpdateGenreCommandHandler(
            IMapper mapper,
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateGenreCommandHandler> logger
        )
        : IRequestHandler<UpdateGenreCommand, Result<GenreDTO>>
    {
        public async Task<Result<GenreDTO>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var genre = mapper.Map<Genre>(request);
                await genreRepository.UpdateAsync(genre);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<GenreDTO>(genre);
                return Result<GenreDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while editing artist, requested data = {request}", request.ToJson());
                return Result<GenreDTO>.Failure("UpdateArtist.Exception", ex.Message);
            }
        }
    }
}
