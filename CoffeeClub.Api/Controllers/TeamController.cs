using CoffeeClub.Application.Features.Team.Commands.CreateTeam;
using CoffeeClub.Application.Features.Team.Queries.GetTeam;
using CoffeeClub.Application.Features.Team.Queries.GetTeamsList;
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
        
        [HttpGet("getTeams")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TeamsListVm>>> GetTeams()
        {
            var teams = await _mediator.Send(new GetTeamsListQuery());
            return Ok(teams);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TeamVm>> GetTeamById(Guid teamId)
        {
            var team = await _mediator.Send(new GetTeamQuery() { TeamId = teamId});
            return Ok(team);
        }
       

    }
}
