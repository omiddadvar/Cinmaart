using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Authors.Queries;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Queries.GetPaginatedAuthor
{
    internal class GetPaginatedAuthorQueryHandler(
         IMapper mapper,
         IAuthorRepository authorRepository,
         ILogger<GetPaginatedAuthorQueryHandler> logger
        ) : IRequestHandler<GetPaginatedAuthorQuery, Result<PagedList<AuthorDTO>>>
    {
        public async Task<Result<PagedList<AuthorDTO>>> Handle(GetPaginatedAuthorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await authorRepository.PaginateAsync(
                    page: request.Page,
                    pageSize: request.PageSize,
                    a => (string.IsNullOrEmpty(request.NameSearchKeyword) || a.Name.Contains(request.NameSearchKeyword)),
                    a => a.OrderBy(e => e.Name),
                    cancellationToken);

                var data = mapper.Map<PagedList<Author>, PagedList<AuthorDTO>>(rawData);
                return Result<PagedList<AuthorDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading paginated Author data, requested data = {request}", request.ToJson());
                return Result<PagedList<AuthorDTO>>.Failure("GetPaginatedAuthors.Exception", ex.Message);
            }
        }
    }
}
