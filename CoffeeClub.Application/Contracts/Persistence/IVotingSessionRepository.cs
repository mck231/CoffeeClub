using System;
using CoffeeClub.Domain.Entities;

namespace CoffeeClub.Application.Contracts.Persistence
{
	public interface IVotingSessionRepository : IAsyncRepository<VotingSession>
	{
        Task<VotingSession> GetVotingSessionWithDetails(Guid sessionId);
        Task UpdateWinningCoffee(Guid sessionId, Guid winningCoffeeId);
        Task UpdateTeam(Guid sessionId, Guid teamId);
        Task<VotingSession> GetVotingSessionWithVotes(Guid voteSessionId);
        Task<IEnumerable<VotingSession>> GetTeamVotingSessions(Guid teamId);
	}
}

