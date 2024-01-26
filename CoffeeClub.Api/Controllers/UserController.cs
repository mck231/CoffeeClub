using CoffeeClub.Application.Features.Team.Queries.GetUsersInTeam;
using CoffeeClub.Application.Features.User.Commands.CreateUser;
using CoffeeClub.Application.Features.User.Commands.UpdateUser;
using CoffeeClub.Application.Features.User.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserDetailsVm>> getUserById(Guid id)
    {
        var user = await _mediator.Send(new GetUserQuery() { UserId = id});
        return Ok(user);
    }
    
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Guid>> CreateTeam([FromBody] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(getUserById), new { id = userId }, userId);
    }
    
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCoffee([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}