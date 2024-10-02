using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Genres.Commands.AddGenre
{
    internal class AddGenreCommandHandler(
            IMapper mapper,
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddGenreCommandHandler> logger
        )
        : IRequestHandler<AddGenreCommand, Result<GenreDTO>>
    {
        public async Task<Result<GenreDTO>> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var genre = mapper.Map<Genre>(request);
                genre = await genreRepository.AddAsync(genre);
                await unitOfWork.SaveAsync(cancellationToken);

                var genreDTO = mapper.Map<GenreDTO>(genre);
                return Result<GenreDTO>.Success(genreDTO);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding genre, requested data = {request}", request.ToJson());
                return Result<GenreDTO>.Failure("AddGenre.Exception", ex.Message);
            }
        }
    }
}
