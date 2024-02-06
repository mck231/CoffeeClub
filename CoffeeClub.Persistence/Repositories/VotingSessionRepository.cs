using CoffeeClub.Persistence.Repositories;
using CoffeeClub.Persistence;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Models;
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

        votingSession.TeamId = teamId;
        await UpdateAsync(votingSession);
    }
    
    public async Task<VotingSession> GetVotingSessionWithVotes(Guid votingSessionId)
    {
        return await _dbContext.VoteSessions
            .Include(vs => vs.Votes)
            .FirstOrDefaultAsync(vs => vs.VotingSessionId == votingSessionId);
    }

    public async Task<IEnumerable<VotingSession>> GetTeamVotingSessions(Guid teamId)
    {
        return await _dbContext.VoteSessions.Where(x => x.TeamId == teamId)
            .Select(y => new VotingSession
            {
                VotingSessionId = y.VotingSessionId,
                CoffeeGroupId = y.CoffeeGroupId,
                StartDate = y.StartDate,
                EndDate = y.EndDate
            }).ToListAsync();
    }
    
    /// <summary>
    /// Retrieves all of the votes for the voting session
    /// </summary>
    /// <param name="votingSessionId">The voting session that will be analyzed for votes</param>
    /// <returns></returns>
    public async Task<List<CoffeeVote>> GetVoteCountsBySessionId(Guid votingSessionId)
    {
        // Doing this because CoffeeVote is not a domain model thus EF Core can not be used.
        var connection = _dbContext.Database.GetDbConnection();
        var command = connection.CreateCommand();
        command.CommandText = $@"
        SELECT 
            c.CoffeeId, 
            c.Name AS CoffeeName, 
            COUNT(v.VoteId) AS Votes 
        FROM Votes v 
        JOIN Coffees c ON v.CoffeeId = c.CoffeeId 
        WHERE v.VotingSessionId = '{votingSessionId}' 
        GROUP BY c.CoffeeId, c.Name";
    
        var coffeeVotes = new List<CoffeeVote>();
        await connection.OpenAsync();
        using (var result = await command.ExecuteReaderAsync())
        {
            while (await result.ReadAsync())
            {
                coffeeVotes.Add(new CoffeeVote
                {
                    CoffeeId = result.GetGuid(result.GetOrdinal("CoffeeId")),
                    CoffeeName = result.GetString(result.GetOrdinal("CoffeeName")),
                    Votes = result.GetInt32(result.GetOrdinal("Votes"))
                });
            }
        }
        await connection.CloseAsync();

        return coffeeVotes;
    }


    
    
}
