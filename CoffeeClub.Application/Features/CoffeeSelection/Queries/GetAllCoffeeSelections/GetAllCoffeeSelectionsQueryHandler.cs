using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Features.CoffeeSelection.Queries.GetCoffeeSelection;
using MediatR;

namespace CoffeeClub.Application.Features.CoffeeSelection.Queries.GetAllCoffeeSelections;

public class GetAllCoffeeSelectionsQueryHandler : IRequestHandler<GetAllCoffeeSelectionsQuery, IEnumerable<CoffeeSelectionSummaryVm>>
{
    private readonly ICoffeeSelectionRepository _coffeeSelectionRepository;

    public GetAllCoffeeSelectionsQueryHandler(ICoffeeSelectionRepository coffeeSelectionRepository)
    {
        _coffeeSelectionRepository = coffeeSelectionRepository;
    }


    public async Task<IEnumerable<CoffeeSelectionSummaryVm>> Handle(GetAllCoffeeSelectionsQuery request, CancellationToken cancellationToken)
    {
        var coffeeGroups = await _coffeeSelectionRepository.GetCoffeeGroups();
        var coffeeSelectionSummaryVms = coffeeGroups.Select(cg => new CoffeeSelectionSummaryVm
        {
            CoffeeGroupId = cg.CoffeeGroupId,
            NumberOfCoffees = cg.CoffeeSelections.Count
        });
        return coffeeSelectionSummaryVms;


    }
}