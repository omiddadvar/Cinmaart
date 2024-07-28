using Cinamaart.Application.Features.Artists.Commands.RemoveArtist;
using Cinamaart.Application.Features.Users.Commands.Register;
using Cinamaart.Application.Features.Users.Commands.RemoveUser;
using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command , CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(long id)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditUser(int id)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        //[Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveUser(RemoveUserCommand command,CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
