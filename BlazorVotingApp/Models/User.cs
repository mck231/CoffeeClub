namespace BlazorVotingApp.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    
    private bool IsLeader { get; set; }
}