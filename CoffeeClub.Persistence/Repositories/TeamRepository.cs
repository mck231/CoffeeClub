using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Persistence.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(CoffeeClubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> GetUsersInTeam(Guid teamId)
        {
            var team = await _dbContext.Teams.FindAsync(teamId);
            if (team == null)
            {
                return new List<User>(); // or throw an exception indicating team not found
            }
            
            return await _dbContext.Users.Where(u => u.TeamId == teamId).ToListAsync();
        }
        public async Task<Team> GetByIdWithMembersAsync(Guid teamId)
        {
            return await _dbContext.Teams
                .Include(t => t.Members)
                .FirstOrDefaultAsync(t => t.TeamId == teamId);
        }
    }
}
