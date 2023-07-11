using System;
using CoffeeClub.Application.Features.CoffeeGroup.Commands.CreateCoffeeGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoffeeGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateCoffeeGroup()
        {
            var command = new CreateCoffeeGroupCommand();
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        //[HttpGet("{id}", Name = "GetCoffeeGroupById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CoffeeGroupDetailsVm>> GetCoffeeGroupById(Guid id)
        //{
        //    var query = new GetCoffeeGroupByIdQuery { Id = id };
        //    var coffeeGroup = await _mediator.Send(query);

        //    if (coffeeGroup == null)
        //        return NotFound();

        //    return Ok(coffeeGroup);
        //}
    }
}

