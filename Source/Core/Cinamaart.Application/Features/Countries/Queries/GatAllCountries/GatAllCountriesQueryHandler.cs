﻿using AutoMapper;
using Cinamaart.Application.Abstractions;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Queries.GatAllCountries
{
    public class GatAllCountriesQueryHandler(
            IMapper mapper,
            ICountryRepository countryRepository,
            ILogger<GatAllCountriesQueryHandler> logger
        ) : IRequestHandler<GatAllCountriesQuery, WebServiceResult<IList<CountryDTO>>>
    {
        public async Task<WebServiceResult<IList<CountryDTO>>> Handle(GatAllCountriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = (await countryRepository.GetAllAsync(cancellationToken: cancellationToken)).ToList();
                var data = mapper.Map<List<CountryDTO>>(countries);
                return WebServiceResult<IList<CountryDTO>>.Success(data);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while reading all country data");
                return WebServiceResult<IList<CountryDTO>>.Failure("GatAllCountries.Exception", ex.Message);

            }
        }
    }
}
