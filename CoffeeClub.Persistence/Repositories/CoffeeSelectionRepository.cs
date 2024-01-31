using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeClub.Persistence.Repositories;

public class CoffeeSelectionRepository : BaseRepository<CoffeeSelection>, ICoffeeSelectionRepository
{
    public CoffeeSelectionRepository(CoffeeClubDbContext dbContext) : base(dbContext)
    {
    }

    

    public async Task<CoffeeGroup> GetCoffeeGroupWithSelections(Guid coffeeGroupId)
    {
        var coffeeGroup = await _dbContext.CoffeeGroups
            .Include(cg => cg.CoffeeSelections)
            .ThenInclude(cs => cs.Coffee)
            .FirstOrDefaultAsync(cg => cg.CoffeeGroupId == coffeeGroupId);
        if (coffeeGroup is null)
        {
            throw new NotFoundException(nameof(coffeeGroup), coffeeGroupId);
        }

        return coffeeGroup;
    }

    public async Task<IEnumerable<CoffeeGroup>> GetCoffeeGroups()
    {
        var coffeeGroups = await _dbContext.CoffeeGroups
            .Include(c => c.CoffeeSelections)
            .ThenInclude(s => s.Coffee)
            .ToListAsync();
        return coffeeGroups;
    }
    
    public async Task BulkAddCoffeeSelections(Guid coffeeGroupId, IEnumerable<Guid> coffeeIds)
    {
        var coffeeGroupExists = await _dbContext.CoffeeGroups.AnyAsync(cg => cg.CoffeeGroupId == coffeeGroupId);
        if (!coffeeGroupExists)
        {
            throw new NotFoundException(nameof(CoffeeGroup), coffeeGroupId);
        }

        var coffeeSelectionsToAdd = coffeeIds.Select(coffeeId => new CoffeeSelection 
            { CoffeeGroupId = coffeeGroupId, 
                CoffeeId = coffeeId 
            }).ToList();

        _dbContext.CoffeeSelections.AddRange(coffeeSelectionsToAdd);
        await _dbContext.SaveChangesAsync();
    }

}