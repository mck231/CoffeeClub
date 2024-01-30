namespace BlazorVotingApp.Models;

public class Team
{
    public Guid TeamId { get; set; }
    public string Name { get; set; }
    public List<TeamMember> Members { get; set; } = new List<TeamMember>();
}