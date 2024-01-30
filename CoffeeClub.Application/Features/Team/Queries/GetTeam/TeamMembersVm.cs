namespace CoffeeClub.Application.Features.Team.Queries.GetTeam;

public class TeamMembersVm
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsLeader { get; set; }

}