namespace CoffeeClub.Application.Features.CoffeeSelection.Queries.GetCoffeeSelection;

public class CoffeeSelectionVm
{
    public Guid CoffeeGroupId { get; set; }
    public IEnumerable<CoffeeSummaryVm> Coffees { get; set; }
}