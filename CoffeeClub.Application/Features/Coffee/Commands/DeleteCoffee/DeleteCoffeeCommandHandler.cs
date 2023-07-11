using System;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using MediatR;

namespace CoffeeClub.Application.Features.Coffee.Commands.DeleteCoffee
{
    public class DeleteCoffeeCommandHandler : IRequestHandler<DeleteCoffeeCommand>
	{
        private readonly IAsyncRepository<Domain.Entities.Coffee> _coffeeRepository;
		public DeleteCoffeeCommandHandler(IAsyncRepository<Domain.Entities.Coffee> coffeeRepository)
		{
            _coffeeRepository = coffeeRepository;

        }

        public async Task Handle(DeleteCoffeeCommand request, CancellationToken cancellationToken)
        {
            var coffee = await _coffeeRepository.GetByIdAsync(request.Id);

            if (coffee is null)
            {
                throw new NotFoundException(nameof(Coffee), request.Id);
            }
            try
            {
                await _coffeeRepository.DeleteAsync(coffee);

            }
            catch (Exception ex)
            {
                var v = ex;
            }
        }
    }
}

