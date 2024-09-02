using Cinamaart.Application.Features.Artists.Queries.GetAllArtists;
using Cinamaart.Application.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Threading;
using Cinamaart.Application.Features.Artists.Queries.GetPaginatedArtists;
using Cinamaart.Application.Features.Artists.Commands.AddArtist;
using Cinamaart.Application.Features.Artists.Queries.GetArtistById;
using Cinamaart.Application.Features.Artists.Commands.UpdateArtist;
using Microsoft.AspNetCore.Authorization;
using Cinamaart.WebAPI.Abstractions.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Cinamaart.Application.Features.Artists.Commands.RemoveArtist;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetArtists(CancellationToken cancellationToken = default)
        {
            var query = new GetAllArtistsQuery();
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("Paginate")]
        public async Task<IActionResult> GetPaginatedArtists(GetPaginatedArtistsQuery query , CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtisById(int id, CancellationToken cancellationToken = default)
        {
            var query = new GetArtistQuery(id);
            var result = await mediator.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> AddArtist(AddArtistCommand command , CancellationToken cancellationToken =default)
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> EditArtist(UpdateArtistCommand command, CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveArtist(int id, CancellationToken cancellationToken = default)
        {
            var command = new RemoveArtistCommand(id);
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
