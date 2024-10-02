using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Movies.Commands.RemoveMovie
{
    internal class RemoveMovieCommandHandler(
            IMovieRepository movieRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveMovieCommandHandler> logger
        ) : IRequestHandler<RemoveMovieCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await movieRepository.DeleteAsync(request.MovieId);
                await unitOfWork.SaveAsync(cancellationToken);
                return WebServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing movie, movieId = {movieId}", request.MovieId);
                return WebServiceResult<bool>.Failure("RemoveMovie.Exception", ex.Message);
            }
        }
    }
}
