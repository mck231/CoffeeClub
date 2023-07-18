using CoffeeClub.Application.Features.Team.Commands.CreateTeam;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateTeam()
        {
            var command = new CreateTeamCommand();
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
