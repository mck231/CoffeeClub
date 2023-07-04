using CoffeeClub.Application.Contracts.Persistence;
using MediatR;
using CoffeeClub.Domain.Entities;

namespace CoffeeClub.Application.Features.Coffee.Commands.CreateCoffee
{
    public class CreateCoffeeCommandHandler : IRequestHandler<CreateCoffeeCommand, Guid>
    {
        private readonly IAsyncRepository<Domain.Entities.Coffee> _coffeeRepository;

        public CreateCoffeeCommandHandler(IAsyncRepository<Domain.Entities.Coffee> coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<Guid> Handle(CreateCoffeeCommand command, CancellationToken cancellationToken)
        {
            var coffee = new Domain.Entities.Coffee
            {
                CoffeeId = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                PurchasingLink = command.PurchasingLink,
                Size = command.Size,
                Origin = command.Origin,
                RoastType = command.RoastType
            };

            await _coffeeRepository.AddAsync(coffee);

            return coffee.CoffeeId;
        }
    }


}
