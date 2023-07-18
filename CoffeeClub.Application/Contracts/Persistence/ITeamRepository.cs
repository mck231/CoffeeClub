using CoffeeClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Contracts.Persistence
{
    public interface ITeamRepository : IAsyncRepository<Team>
    {
        Task<List<User>> GetUsersInTeam(Guid teamId);

    }
}
