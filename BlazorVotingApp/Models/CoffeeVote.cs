namespace BlazorVotingApp.Models;

public class CoffeeVote
{
    public string CoffeeName { get; set; } = string.Empty;
    public Guid CoffeeGuid { get; set; }
    public int Votes { get; set; }
}