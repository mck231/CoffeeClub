namespace CoffeeClub.Application.Features.CoffeeSelection.Queries.GetCoffeeSelection;

public class CoffeeSummaryVm
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CoffeeId { get; set; }
}