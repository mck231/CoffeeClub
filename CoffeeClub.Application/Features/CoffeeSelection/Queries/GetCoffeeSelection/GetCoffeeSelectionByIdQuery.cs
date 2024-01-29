using MediatR;

namespace CoffeeClub.Application.Features.CoffeeSelection.Queries.GetCoffeeSelection;

public class GetCoffeeSelectionByIdQuery : IRequest<CoffeeSelectionVm>
{
    public required Guid CoffeeSelectionId { get; set; }

}