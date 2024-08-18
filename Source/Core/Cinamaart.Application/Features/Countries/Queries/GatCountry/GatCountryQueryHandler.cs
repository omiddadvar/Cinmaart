using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.SharedKernel;
using Cinamaart.SharedKernel.Resources;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Queries.GatCountry
{
    public class GatCountryQueryHandler(
            IMapper mapper,
            ICountryRepository countryRepository,
            ILogger<GatCountryQueryHandler> logger,
            IStringLocalizer<StringResources> stringLocalizer
        ) : IRequestHandler<GatCountryQuery, Result<CountryDTO>>
    {
        public async Task<Result<CountryDTO>> Handle(GatCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var country = await countryRepository.GetAsync(request.Id);
                if (country is null)
                {
                    return Result<CountryDTO>.Failure("Country.NotFound" ,
                        stringLocalizer[LocalStringKeyword.Country_NotFound]);
                }
                var countryDTO = mapper.Map<CountryDTO>(country);
                return Result<CountryDTO>.Success(countryDTO);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while reading country data, countryId = {ArtistId}", request.Id);
                return Result<CountryDTO>.Failure("GatCountry.Exception", ex.Message);
            }
        }
    }
}
