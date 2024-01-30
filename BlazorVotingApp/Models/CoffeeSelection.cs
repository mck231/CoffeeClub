namespace BlazorVotingApp.Models;

public class CoffeeSelection
{
    public Guid CoffeeGroupId { get; set; }
    public IEnumerable<CoffeeSummary> Coffees { get; set; }
}