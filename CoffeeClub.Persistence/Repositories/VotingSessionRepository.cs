using CoffeeClub.Persistence.Repositories;
using CoffeeClub.Persistence;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class VotingSessionRepository : BaseRepository<VotingSession>, IVotingSessionRepository
{
    private readonly ICoffeeRepository _coffeeRepository;
    private readonly ITeamRepository _teamRepository;

    public VotingSessionRepository(CoffeeClubDbContext dbContext, ICoffeeRepository coffeeRepository, ITeamRepository teamRepository)
        : base(dbContext)
    {
        _coffeeRepository = coffeeRepository;
        _teamRepository = teamRepository;
    }

    public async Task<VotingSession> GetVotingSessionWithDetails(Guid sessionId)
    {
        var votingSession = await _dbContext.VoteSessions
             .Include(vs => vs.Votes)
             .Include(c => c.CoffeeGroup)
             .Include(t => t.Team)
             .SingleOrDefaultAsync(vs => vs.VotingSessionId == sessionId);

        if (votingSession == null)
        {
            throw new NotFoundException(nameof(VotingSession), sessionId);
        }

        return votingSession;
    }

    public async Task UpdateWinningCoffee(Guid sessionId, Guid winningCoffeeId)
    {
        var votingSession = await GetByIdAsync(sessionId);
        if (votingSession == null)
        {
            throw new NotFoundException(nameof(VotingSession), sessionId);
        }

        var coffee = await _coffeeRepository.GetByIdAsync(winningCoffeeId);
        if (coffee == null)
        {
            throw new NotFoundException(nameof(Coffee), winningCoffeeId);
        }

        // Call the base repository's UpdateAsync method to persist the changes
        await UpdateAsync(votingSession);
    }

    public async Task UpdateTeam(Guid sessionId, Guid teamId)
    {
        var votingSession = await GetByIdAsync(sessionId);
        if (votingSession == null)
        {
            throw new NotFoundException(nameof(VotingSession), sessionId);
        }

        var team = await _teamRepository.GetByIdAsync(teamId);
        if (team == null)
        {
            throw new NotFoundException(nameof(Team), teamId);
        }

        // Update the TeamId property in the votingSession object
        votingSession.TeamId = teamId;

        // Call the base repository's UpdateAsync method to persist the changes
        await UpdateAsync(votingSession);
    }
    
    public async Task<VotingSession> GetVotingSessionWithVotes(Guid votingSessionId)
    {
        return await _dbContext.VoteSessions
            .Include(vs => vs.Votes)
            .FirstOrDefaultAsync(vs => vs.VotingSessionId == votingSessionId);
    }

}
