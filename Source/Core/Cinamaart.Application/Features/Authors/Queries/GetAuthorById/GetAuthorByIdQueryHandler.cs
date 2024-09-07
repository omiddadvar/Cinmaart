using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Queries.GetAuthorById
{
    internal class GetAuthorByIdQueryHandler(
            IMapper mapper,
            IAuthorRepository authorRepository,
            ILogger<GetAuthorByIdQueryHandler> logger
        ) : IRequestHandler<GetAuthorByIdQuery, Result<AuthorDTO>>
    {
        public async Task<Result<AuthorDTO>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Author = await authorRepository.GetAsync(request.AuthorId, cancellationToken);
                var data = mapper.Map<AuthorDTO>(Author);
                return Result<AuthorDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading Author data, Authorid = {AuthorId}", request.AuthorId);
                return Result<AuthorDTO>.Failure("GetAuthor.Exception", ex.Message);
            }
        }
    }
}
