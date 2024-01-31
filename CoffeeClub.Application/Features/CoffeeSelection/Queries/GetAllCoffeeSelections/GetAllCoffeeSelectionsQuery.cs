using CoffeeClub.Application.Features.CoffeeSelection.Queries.GetCoffeeSelection;
using MediatR;

namespace CoffeeClub.Application.Features.CoffeeSelection.Queries.GetAllCoffeeSelections;

public class GetAllCoffeeSelectionsQuery : IRequest<IEnumerable<CoffeeSelectionSummaryVm>>
{
    
}