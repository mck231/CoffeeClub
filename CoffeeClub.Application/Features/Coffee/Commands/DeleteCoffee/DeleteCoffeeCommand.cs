using System;
using MediatR;

namespace CoffeeClub.Application.Features.Coffee.Commands.DeleteCoffee
{
	public class DeleteCoffeeCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}

