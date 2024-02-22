using System;
using System.Threading.Tasks;
using CoffeeClub.Application.Features.VotingSession.Commands.EditVotingSession;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionExcelFileQuery;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionsByTeam;
using CoffeeClub.Application.Features.VottingSession.Commands.CreateVotingSession;
using CoffeeClub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotingSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("getVotingSessionDetails")]
        public async Task<IActionResult> GetVotingSessionDetails(Guid voteSessionId)
        {
            var votingSession = await _mediator.Send(new GetVotingSessionQuery() { VotingSessionId = voteSessionId});
            return Ok(votingSession);
        }
        
        [HttpGet("byTeam/{teamId}")]
        public async Task<IActionResult> GetVotingSessionsByTeam(Guid teamId)
        {
            var votingSession = await _mediator.Send(new GetVotingSessionsByTeamQuery() { TeamId = teamId});
            return Ok(votingSession);
        }

        [HttpGet("getExcelFile/{voteSessionId}")]
        public async Task<IActionResult> GetExcelResultsFromVotingSession(Guid voteSessionId)
        {
            var fileBytes = await _mediator.Send(new GetVotingSessionExcelFileQuery { VotingSessionId = voteSessionId });
            return File(fileBytes, "text/csv", $"voting-session-{voteSessionId}.csv");
        }


        /*[HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateVotingSession(CreateVotingSessionCommand command)
        {
            var sessionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetVotingSession), new { id = sessionId }, sessionId);
        }*/

        /*[HttpGet("{id}", Name = "GetVotingSession")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VotingSessionVm>> GetVotingSession(Guid id)
        {
            var query = new GetVotingSessionQuery { VotingSessionId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }*/

       
    }
}
