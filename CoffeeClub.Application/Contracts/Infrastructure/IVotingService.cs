using CoffeeClub.Application.Models;

namespace CoffeeClub.Application.Contracts.Infrastructure;

public interface IVotingService
{
    Task ProcessVote(Guid votingSessionId, Guid coffeeId, Guid userId);
    Task<List<CoffeeVote>> GetUpdatedVotes(Guid votingSessionId);
}