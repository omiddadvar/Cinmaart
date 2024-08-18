﻿using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.Application.Features.Countries.Queries.GatAllCountries;
using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;
using Cinamaart.Application.Features.Countries.Queries.GatCountry;
using Cinamaart.Application.Features.Countries.Commands.AddCountry;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Cinamaart.Application.Features.Countries.Commands.UpdateCountry;
using Cinamaart.Application.Features.Countries.Commands.RemoveCountry;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Country])]
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken = default)
        {
            var query = new GatAllCountriesQuery();
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = CachePolicyNames.OutputCacheWithAuth, Tags = [CacheTags.Country])]
        public async Task<IActionResult> GetCountryById(int id, CancellationToken cancellationToken = default)
        {
            var query = new GatCountryQuery(id);
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> AddCountry(AddCountryCommand command, CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                await cacheStore.EvictByTagAsync(CacheTags.Country, cancellationToken);
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> EditCountry(UpdateCountryCommand command , CancellationToken cancellationToken =default)
        {
            var result = await mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                await cacheStore.EvictByTagAsync(CacheTags.Country, cancellationToken);
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpDelete]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveCountry(RemoveCountryCommand command, CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                await cacheStore.EvictByTagAsync(CacheTags.Country, cancellationToken);
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
