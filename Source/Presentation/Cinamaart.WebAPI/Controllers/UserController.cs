using Cinamaart.Application.Features.Users.Commands.Register;
using Cinamaart.Application.Features.Users.Commands.RemoveUser;
using Cinamaart.Application.Features.Users.Queries.GetUserById;
using Cinamaart.WebAPI.Abstractions.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Threading;

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
        public async Task<IActionResult> GetUser(long id, CancellationToken cancellationToken = default)
        {
            var command = new GetUserByIdCommand(id);
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditUser(int id)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = RoleNames.Administrator)]
        public async Task<IActionResult> RemoveUser(long id,CancellationToken cancellationToken = default)
        {
            var command = new RemoveUserCommand(id);
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
