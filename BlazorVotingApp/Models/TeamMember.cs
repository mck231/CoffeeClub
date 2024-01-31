namespace BlazorVotingApp.Models;

public class TeamMember
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsLeader { get; set; }
}