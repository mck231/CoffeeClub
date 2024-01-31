namespace BlazorVotingApp.Models;

public class VotingSession
{
    public Guid VotingSessionId { get; set; }
    public Guid CoffeeGroupId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}