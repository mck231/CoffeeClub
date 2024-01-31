using CoffeeClub.Application.Contracts.Infrastructure;
using MediatR;

namespace CoffeeClub.Application.Features.Voting.CastVote;

public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand>
{
    private readonly IVotingService _votingService;

    public CastVoteCommandHandler(IVotingService votingService)
    {
        _votingService = votingService;
    }
    public async Task Handle(CastVoteCommand request, CancellationToken cancellationToken)
    {
        await _votingService.ProcessVote(request.VotingSessionId, request.CoffeeId, request.UserId);
    }
}