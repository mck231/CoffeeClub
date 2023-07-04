using CoffeeClub.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffeeList
{
    public class GetCoffeeListQueryHandler : IRequestHandler<GetCoffeeListQuery, CoffeeListVm>
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public GetCoffeeListQueryHandler(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<CoffeeListVm> Handle(GetCoffeeListQuery query, CancellationToken cancellationToken)
        {
            var coffees = await _coffeeRepository.GetCoffeesByIds(query.CoffeeGuids);

            var coffeeDtos = coffees.Select(coffee => new CoffeeDto
            {
                Name = coffee.Name,
                Price = coffee.Price,
                RoastType = coffee.RoastType
            }).ToList();

            var coffeeListVm = new CoffeeListVm
            {
                Coffees = coffeeDtos
            };

            return coffeeListVm;
        }
    }

}
