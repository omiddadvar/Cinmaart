using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Authors.Commands.RemoveAuthor
{
    internal class RemoveAuthorCoammandHandler(
            IMapper mapper,
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveAuthorCoammandHandler> logger
        ) : IRequestHandler<RemoveAuthorCoammand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveAuthorCoammand request, CancellationToken cancellationToken)
        {
            try
            {
                await authorRepository.DeleteAsync(request.AuthorId);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while removing Author, AuthorId = {AuthorId}", request.AuthorId);
                return Result<bool>.Failure("RemoveAuthor.Exception", ex.Message);
            }
        }
    }
}
