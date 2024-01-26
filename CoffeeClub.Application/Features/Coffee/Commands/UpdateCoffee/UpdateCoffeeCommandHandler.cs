using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Features.Coffee.Commands.CreateCoffee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Commands.UpdateCoffee
{
    public class UpdateCoffeeCommandHandler : IRequestHandler<UpdateCoffeeCommand, Guid>
    {
        private readonly IAsyncRepository<Domain.Entities.Coffee> _coffeeRepository;

        public UpdateCoffeeCommandHandler(IAsyncRepository<Domain.Entities.Coffee> coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<Guid> Handle(UpdateCoffeeCommand request, CancellationToken cancellationToken)
        {
            var existingCoffee = await _coffeeRepository.GetByIdAsync(request.Id);

            if (existingCoffee == null)
            {
              
                throw new NotFoundException(nameof(Coffee), request.Id);
            }

            // Update the properties of the existing coffee
            existingCoffee.Name = request.Name;
            existingCoffee.Description = request.Description;
            existingCoffee.Price = request.Price;
            existingCoffee.PurchasingLink = request.PurchasingLink;
            existingCoffee.Size = request.Size;
            existingCoffee.Origin = request.Origin;
            existingCoffee.RoastType = request.RoastType;

            await _coffeeRepository.UpdateAsync(existingCoffee);

            return existingCoffee.CoffeeId;
        }
       
    }
}
