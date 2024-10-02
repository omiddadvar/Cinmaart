using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Genres.Commands.RemoveGenre
{
    internal class RemoveGenreCommandHandler(
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveGenreCommandHandler> logger
        )
        : IRequestHandler<RemoveGenreCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await genreRepository.DeleteAsync(request.Id);
                await unitOfWork.SaveAsync(cancellationToken);
                return WebServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing genre, genreId = {Id}", request.Id);
                return WebServiceResult<bool>.Failure("RemoveGenre.Exception", ex.Message);
            }
        }
    }
}
