using MediatR;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionsByTeam;

public class GetVotingSessionsByTeamQuery : IRequest<TeamVotingSessionsVm>
{
    public Guid TeamId { get; set; }
}