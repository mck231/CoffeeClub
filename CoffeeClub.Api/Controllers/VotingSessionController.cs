/*
using System;
using System.Threading.Tasks;
using CoffeeClub.Application.Features.VotingSession.Commands.CreateVotingSession;
using CoffeeClub.Application.Features.VotingSession.Commands.DeleteVotingSession;
using CoffeeClub.Application.Features.VotingSession.Commands.EditVotingSession;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionWithDetails;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateVotingSession(CreateVotingSessionCommand command)
        {
            var sessionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetVotingSession), new { id = sessionId }, sessionId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditVotingSession(Guid id, EditVotingSessionCommand command)
        {
            if (id != command.VotingSessionId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVotingSession(Guid id)
        {
            var command = new DeleteVotingSessionCommand { VotingSessionId = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetVotingSession")]
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
        }

        [HttpGet("details/{id}", Name = "GetVotingSessionWithDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VotingSessionDetailsVm>> GetVotingSessionWithDetails(Guid id)
        {
            var query = new GetVotingSessionWithDetailsQuery { VotingSessionId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
*/
