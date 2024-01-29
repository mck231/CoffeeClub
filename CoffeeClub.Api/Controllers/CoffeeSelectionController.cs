using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeeSelectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoffeeSelectionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffeeSelectionById(Guid id)
    {
        // Assuming you have a GetCoffeeSelectionByIdQuery
        var coffeeSelection = await _mediator.Send(new GetCoffeeSelectionByIdQuery(id));
        return Ok(coffeeSelection);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCoffeeSelections()
    {
        // Assuming you have a GetAllCoffeeSelectionsQuery
        var coffeeSelections = await _mediator.Send(new GetAllCoffeeSelectionsQuery());
        return Ok(coffeeSelections);
    }

    [HttpPost("bulk-add")]
    public async Task<IActionResult> BulkAddCoffeeSelections([FromBody] BulkAddCoffeeSelectionsCommand command)
    {
        // Command should include CoffeeGroupId and a List of CoffeeIds
        await _mediator.Send(command);
        return NoContent(); // or return Created response if appropriate
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoffeeSelection(Guid id, [FromBody] UpdateCoffeeSelectionCommand command)
    {
        if (id != command.CoffeeSelectionId)
        {
            return BadRequest("Mismatched ID in request");
        }

        await _mediator.Send(command);
        return NoContent();
    }


}