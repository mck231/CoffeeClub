using CoffeeClub.Domain.Entities;

namespace CoffeeClub.Application.Contracts.Persistence;

public interface ICoffeeSelectionRepository : IAsyncRepository<CoffeeSelection>
{
    Task<CoffeeGroup> GetCoffeeGroupWithSelections(Guid coffeeSelectionId);
    Task<IEnumerable<CoffeeGroup>> GetCoffeeGroups();
    Task BulkAddCoffeeSelections(Guid coffeeGroupId, IEnumerable<Guid> coffeeIds);


}