﻿using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Authors.Queries;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Authors.Queries.GetAllAuthors
{
    internal class GetAllAuthorsQueryHandler(
            IMapper mapper,
            IAuthorRepository authorRepository,
            ILogger<GetAllAuthorsQueryHandler> logger
        ) : IRequestHandler<GetAllAuthorsQuery, WebServiceResult<IList<AuthorDTO>>>
    {
        public async Task<WebServiceResult<IList<AuthorDTO>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await authorRepository.GetAsync(
                    Where: null,
                    a => a.OrderBy(e => e.Name),
                    cancellationToken);

                var data = mapper.Map<List<AuthorDTO>>(rawData.ToList());
                return WebServiceResult<IList<AuthorDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading all Author data");
                return WebServiceResult<IList<AuthorDTO>>.Failure("GetAllAuthors.Exception", ex.Message);
            }
        }
    }
}
