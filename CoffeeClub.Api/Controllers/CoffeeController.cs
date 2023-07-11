using CoffeeClub.Application.Features.Coffee.Commands.CreateCoffee;
using CoffeeClub.Application.Features.Coffee.Commands.DeleteCoffee;
using CoffeeClub.Application.Features.Coffee.Commands.UpdateCoffee;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffeeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : Controller
    {
        private readonly IMediator _mediator;

        public CoffeeController(IMediator mediator)
        {            
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetCoffeeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CoffeeDetailsVm>>> GetCoffeeById(Guid id)
        {
            var dtos = await _mediator.Send(new GetCoffeeQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpPost("getList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CoffeeListVm>> GetCoffeeList([FromBody] List<Guid> coffeeIds)
        {
            var query = new GetCoffeeListQuery { CoffeeGuids = coffeeIds };
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateCoffee([FromBody] CreateCoffeeCommand command)
        {
            var coffeeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCoffeeById), new { id = coffeeId }, coffeeId);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCoffee([FromBody] UpdateCoffeeCommand command)
        {
            if(command.Id == null || command.Id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCoffee(Guid id)
        {
            var command = new DeleteCoffeeCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
