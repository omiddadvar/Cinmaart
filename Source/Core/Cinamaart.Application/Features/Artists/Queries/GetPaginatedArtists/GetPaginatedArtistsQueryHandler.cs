using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Queries.GetPaginatedArtists
{
    public class GetPaginatedArtistsQueryHandler(
        IMapper mapper,
        IArtistRepository artistRepository) 
        : IRequestHandler<GetPaginatedArtistsQuery, Result<PagedList<GetArtistsDTO>>>
    {
        public async Task<Result<PagedList<GetArtistsDTO>>> Handle(GetPaginatedArtistsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await artistRepository.PaginateAsync(
                    page : request.Page,
                    pageSize : request.PageSize,
                    (a =>  (string.IsNullOrEmpty(request.NameSearchKeyword) || a.FullName.Contains(request.NameSearchKeyword)
                     && (request.Countries.IsNullOrEmpty<int>() || request.Countries.Contains(a.CountryId ?? -1)))),
                    a => a.OrderBy(e => e.FullName),
                    cancellationToken,
                a => a.Country, e => e.Gender);

                var data = mapper.Map<PagedList<Artist>,PagedList<GetArtistsDTO>>(rawData);
                return Result<PagedList<GetArtistsDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<PagedList<GetArtistsDTO>>.Failure("GetPaginatedArtists.Exception", ex.Message);
            }
        }
    }
}
