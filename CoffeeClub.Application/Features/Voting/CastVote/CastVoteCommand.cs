using MediatR;

namespace CoffeeClub.Application.Features.Voting.CastVote;

public class CastVoteCommand : IRequest  // Define ResultType as per your logic
{
    public Guid VotingSessionId { get; set; }
    public Guid CoffeeId { get; set; }
    public Guid UserId { get; set; }

}