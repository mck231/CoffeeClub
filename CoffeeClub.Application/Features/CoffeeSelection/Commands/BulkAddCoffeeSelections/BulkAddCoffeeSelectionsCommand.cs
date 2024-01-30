using MediatR;

namespace CoffeeClub.Application.Features.CoffeeSelection.Commands.BulkAddCoffeeSelections;

public class BulkAddCoffeeSelectionsCommand : IRequest
{
    public Guid CoffeeGroupId { get; set; }
    public List<Guid> CoffeeIds { get; set; }
}