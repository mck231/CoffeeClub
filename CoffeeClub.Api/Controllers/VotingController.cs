using CoffeeClub.Application.Features.Voting.CastVote;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VotingController : ControllerBase
{
    private readonly IMediator _mediator;  // Assuming you're using MediatR

    public VotingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("castVote")]
    public async Task<IActionResult> CastVote([FromBody] CastVoteCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

  
}
