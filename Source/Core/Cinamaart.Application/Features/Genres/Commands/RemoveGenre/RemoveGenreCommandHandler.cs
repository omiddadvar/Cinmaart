using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Genres.Commands.RemoveGenre
{
    internal class RemoveGenreCommandHandler(
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveGenreCommandHandler> logger
        )
        : IRequestHandler<RemoveGenreCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await genreRepository.DeleteAsync(request.Id);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing genre, genreId = {Id}", request.Id);
                return Result<bool>.Failure("RemoveGenre.Exception", ex.Message);
            }
        }
    }
}
