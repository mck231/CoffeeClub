using CoffeeClub.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace CoffeeClub.Api.Hubs;

public class VotingHub : Hub
{
    private readonly IVotingService _votingService;

    public VotingHub(IVotingService votingService)
    {
        _votingService = votingService;
    }

    public async Task CastVote(Guid votingSessionId, Guid coffeeId, Guid userId)
    {
        try
        {
            await _votingService.ProcessVote(votingSessionId, coffeeId, userId);

            var updatedVotes = await _votingService.GetUpdatedVotes(votingSessionId);

            await Clients.All.SendAsync("ReceiveVoteUpdate", updatedVotes);
        }
        catch (Exception ex)
        {
            // Log and handle unexpected exceptions
            Console.WriteLine($"Error in CastVote: {ex.Message}");
            await Clients.Caller.SendAsync("ReceiveVoteError", "An unexpected error occurred.");
        }
    }
    
    public async Task GetCurrentVotingResults(Guid sessionId)
    {
        var updatedVotes = await _votingService.GetUpdatedVotes(sessionId);
        await Clients.Caller.SendAsync("ReceiveVoteUpdate", updatedVotes);
    }

}