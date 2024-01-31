using CoffeeClub.Application.Contracts.Persistence;
using MediatR;

namespace CoffeeClub.Application.Features.CoffeeSelection.Commands.BulkAddCoffeeSelections;

public class BulkAddCoffeeSelectionsCommandHandler : IRequestHandler<BulkAddCoffeeSelectionsCommand>
{
    private readonly ICoffeeSelectionRepository _coffeeSelectionRepository;

    public BulkAddCoffeeSelectionsCommandHandler(ICoffeeSelectionRepository coffeeSelectionRepository)
    {
        _coffeeSelectionRepository = coffeeSelectionRepository;
    }

    public async Task Handle(BulkAddCoffeeSelectionsCommand command, CancellationToken cancellationToken)
    {
        await _coffeeSelectionRepository.BulkAddCoffeeSelections(command.CoffeeGroupId, command.CoffeeIds);

    }
}