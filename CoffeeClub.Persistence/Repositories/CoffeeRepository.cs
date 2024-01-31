using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffeeList;
using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Persistence.Repositories
{
    public class CoffeeRepository : BaseRepository<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(CoffeeClubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Coffee>> GetCoffeesByIds(List<Guid> coffeesIds)
        {
            var hashedGuids = new HashSet<Guid>(coffeesIds);
            var coffee = _dbContext.Coffees.Where(x => hashedGuids.Contains(x.CoffeeId)).ToList();
            return coffee;
        }
    }
}
