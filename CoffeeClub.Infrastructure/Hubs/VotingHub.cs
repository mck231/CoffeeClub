using CoffeeClub.Application.Contracts.Infrastructure;

namespace CoffeeClub.Infrastructure.Hubs;

public class VotingHub
{
    private readonly IVotingService _votingService; // Defined in the application layer

    public VotingHub(IVotingService votingService)
    {
        _votingService = votingService;
    }
    public async Task CastVote(Guid votingSessionId, Guid coffeeId, Guid userId)
    {
        await _votingService.ProcessVote(votingSessionId, coffeeId, userId);
        // SignalR logic to update clients
    }
}