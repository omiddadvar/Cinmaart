using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Authors.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Commands.UpdateAuthor
{
    internal class UpdateAuthorCommandHandler(
        IMapper mapper,
        IAuthorRepository authorRepository,
        IUnitOfWork unitOfWork,
        ILogger<UpdateAuthorCommandHandler> logger
        ) : IRequestHandler<UpdateAuthorCommand, WebServiceResult<AuthorDTO>>
    {
        public async Task<WebServiceResult<AuthorDTO>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Author = mapper.Map<Author>(request);
                await authorRepository.UpdateAsync(Author);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<AuthorDTO>(Author);
                return WebServiceResult<AuthorDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while editing Author, requested data = {request}", request.ToJson());
                return WebServiceResult<AuthorDTO>.Failure("UpdateAuthor.Exception", ex.Message);
            }
        }
    }
}
