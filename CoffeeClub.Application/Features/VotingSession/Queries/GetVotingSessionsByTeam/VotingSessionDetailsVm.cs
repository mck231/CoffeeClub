namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionsByTeam;

public class VotingSessionDetailsVm
{
    public Guid VotingSessionId { get; set; }
    public Guid CoffeeGroupId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}