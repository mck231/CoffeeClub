namespace CoffeeClub.Application.Models;

public class CoffeeVote
{
    public string CoffeeName { get; set; } = string.Empty;
    public Guid CoffeeId { get; set; }
    public int Votes { get; set; }
}