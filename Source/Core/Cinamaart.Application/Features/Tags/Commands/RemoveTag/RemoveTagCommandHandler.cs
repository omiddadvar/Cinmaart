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

namespace Cinamaart.Application.Features.Tags.Commands.RemoveTag
{
    internal class RemoveTagCommandHandler(
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveTagCommandHandler> logger
        ) : IRequestHandler<RemoveTagCommand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await tagRepository.DeleteAsync(request.Id);
                await unitOfWork.SaveAsync(cancellationToken);
                return WebServiceResult<bool>.Success(true);
            }
            catch(Exception ex )
            {
                logger.LogError(ex, "Error while removing tag, genreId = {Id}", request.Id);
                return WebServiceResult<bool>.Failure("RemoveTag.Exception", ex.Message);
            }
        }
    }
}
