using System;
using CoffeeClub.Application.Contracts.Persistence;
using MediatR;

namespace CoffeeClub.Application.Features.CoffeeGroup.Commands.CreateCoffeeGroup
{
	public class CreateCoffeeGroupCommandHandler : IRequestHandler<CreateCoffeeGroupCommand>
    { 
        private readonly IAsyncRepository<Domain.Entities.CoffeeGroup> _coffeeGroupRepository;
    
        public CreateCoffeeGroupCommandHandler(IAsyncRepository<Domain.Entities.CoffeeGroup> coffeeGroupRepository)
		{
            _coffeeGroupRepository = coffeeGroupRepository;

        }

        public async Task Handle(CreateCoffeeGroupCommand request, CancellationToken cancellationToken)
        {
            var coffeeGroup = new Domain.Entities.CoffeeGroup
            {
                CoffeeGroupId = Guid.NewGuid()
            };
            await _coffeeGroupRepository.AddAsync(coffeeGroup);
        }
    }
}

