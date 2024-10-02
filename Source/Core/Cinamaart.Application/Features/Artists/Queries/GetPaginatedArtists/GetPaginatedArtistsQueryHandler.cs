using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Artists.Queries.GetPaginatedArtists
{
    public class GetPaginatedArtistsQueryHandler(
        IMapper mapper,
        IArtistRepository artistRepository,
        ILogger<GetPaginatedArtistsQueryHandler> logger)
        : IRequestHandler<GetPaginatedArtistsQuery, WebServiceResult<PagedList<GetArtistDTO>>>
    {
        public async Task<WebServiceResult<PagedList<GetArtistDTO>>> Handle(GetPaginatedArtistsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rawData = await artistRepository.PaginateAsync(
                    page: request.Page,
                    pageSize: request.PageSize,
                    (a => (string.IsNullOrEmpty(request.NameSearchKeyword) || a.FullName.Contains(request.NameSearchKeyword)
                     && (request.Countries.IsNullOrEmpty<int>() || request.Countries.Contains(a.CountryId ?? -1)))),
                    a => a.OrderBy(e => e.FullName),
                    cancellationToken,
                a => a.Country, e => e.Gender);

                var data = mapper.Map<PagedList<Artist>, PagedList<GetArtistDTO>>(rawData);
                return WebServiceResult<PagedList<GetArtistDTO>>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while reading paginated artist data, requested data = {request}", request.ToJson());
                return WebServiceResult<PagedList<GetArtistDTO>>.Failure("GetPaginatedArtists.Exception", ex.Message);
            }
        }
    }
}
