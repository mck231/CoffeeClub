using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using MediatR;

namespace CoffeeClub.Application.Features.CoffeeSelection.Queries.GetCoffeeSelection;

public class GetCoffeeSelectionByIdQueryHandler : IRequestHandler<GetCoffeeSelectionByIdQuery, CoffeeSelectionVm>
{
    private readonly ICoffeeSelectionRepository _coffeeSelectionRepository;

    public GetCoffeeSelectionByIdQueryHandler(ICoffeeSelectionRepository coffeeSelectionRepository)
    {
        _coffeeSelectionRepository = coffeeSelectionRepository;
    }

    public async Task<CoffeeSelectionVm> Handle(GetCoffeeSelectionByIdQuery request, CancellationToken cancellationToken)
    {
        var coffeeGroup = await _coffeeSelectionRepository.GetCoffeeGroupWithSelections(request.CoffeeGroupId);
        if (coffeeGroup == null)
        {
            throw new NotFoundException(nameof(CoffeeGroup), request.CoffeeGroupId);
        }

        var coffeeSelectionVm = new CoffeeSelectionVm
        {
            CoffeeGroupId = coffeeGroup.CoffeeGroupId,
            Coffees = coffeeGroup.CoffeeSelections.Select(cs => new CoffeeSummaryVm
            {
                Name = cs.Coffee.Name,
                Description = cs.Coffee.Description,
                Price = cs.Coffee.Price,
                CoffeeId = cs.CoffeeId
            })
        };

        return coffeeSelectionVm;
    }
}
