using System;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Domain.Entities;

namespace CoffeeClub.Persistence.Repositories
{
    public class CoffeeGroupRepository : BaseRepository<CoffeeGroup>, ICoffeeGroupRepository
    {
        public CoffeeGroupRepository(CoffeeClubDbContext dbContext) : base(dbContext)
        {
        }
    }
}

