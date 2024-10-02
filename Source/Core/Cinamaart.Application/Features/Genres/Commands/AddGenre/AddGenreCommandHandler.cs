using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
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

namespace Cinamaart.Application.Features.Genres.Commands.AddGenre
{
    internal class AddGenreCommandHandler(
            IMapper mapper,
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddGenreCommandHandler> logger
        )
        : IRequestHandler<AddGenreCommand, WebServiceResult<GenreDTO>>
    {
        public async Task<WebServiceResult<GenreDTO>> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var genre = mapper.Map<Genre>(request);
                genre = await genreRepository.AddAsync(genre);
                await unitOfWork.SaveAsync(cancellationToken);

                var genreDTO = mapper.Map<GenreDTO>(genre);
                return WebServiceResult<GenreDTO>.Success(genreDTO);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding genre, requested data = {request}", request.ToJson());
                return WebServiceResult<GenreDTO>.Failure("AddGenre.Exception", ex.Message);
            }
        }
    }
}
