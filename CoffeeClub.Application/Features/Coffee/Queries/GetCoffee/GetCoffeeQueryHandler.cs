using AutoMapper;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffee
{
    public class GetCoffeeQueryHandler : IRequestHandler<GetCoffeeQuery, CoffeeDetailsVm>
    {
        private readonly IAsyncRepository<Domain.Entities.Coffee> _coffeeRepository;
        private readonly IMapper _mapper;


        public GetCoffeeQueryHandler(IAsyncRepository<Domain.Entities.Coffee> coffeeRepository, IMapper mapper)
        {
            _coffeeRepository = coffeeRepository;
            _mapper = mapper;
        }

        public async Task<CoffeeDetailsVm> Handle(GetCoffeeQuery query, CancellationToken cancellationToken)
        {
            var coffee = await _coffeeRepository.GetByIdAsync(query.Id);

            if (coffee == null)
            {
                throw new NotFoundException(nameof(Coffee), query.Id);
            }
           
            return _mapper.Map<CoffeeDetailsVm>(coffee);
        }
    }
}
