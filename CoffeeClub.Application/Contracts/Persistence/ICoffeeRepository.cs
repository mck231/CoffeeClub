using CoffeeClub.Application.Features.Coffee.Queries.GetCoffeeList;
using CoffeeClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Contracts.Persistence
{
    public interface ICoffeeRepository : IAsyncRepository<Coffee>
    {
        Task<List<Coffee>> GetCoffeesByIds(List<Guid> coffeesIds);
    }
}
