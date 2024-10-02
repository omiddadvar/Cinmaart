using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Authors.Commands.RemoveAuthor
{
    internal class RemoveAuthorCoammandHandler(
            IMapper mapper,
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveAuthorCoammandHandler> logger
        ) : IRequestHandler<RemoveAuthorCoammand, WebServiceResult<bool>>
    {
        public async Task<WebServiceResult<bool>> Handle(RemoveAuthorCoammand request, CancellationToken cancellationToken)
        {
            try
            {
                await authorRepository.DeleteAsync(request.AuthorId);
                await unitOfWork.SaveAsync(cancellationToken);
                return WebServiceResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing Author, AuthorId = {AuthorId}", request.AuthorId);
                return WebServiceResult<bool>.Failure("RemoveAuthor.Exception", ex.Message);
            }
        }
    }
}
