using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Authors.Commands.AddAuthor
{
    internal class AddAuthorCommandHandler(
            IMapper mapper,
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddAuthorCommandHandler> logger
        ) : IRequestHandler<AddAuthorCommand, WebServiceResult<AuthorDTO>>
    {
        public async Task<WebServiceResult<AuthorDTO>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Author = mapper.Map<Author>(request);
                Author = await authorRepository.AddAsync(Author);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<AuthorDTO>(Author);
                return WebServiceResult<AuthorDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding Author, requested data = {request}", request.ToJson());
                return WebServiceResult<AuthorDTO>.Failure("AddAuthor.Exception", ex.Message);
            }
        }
    }
}
