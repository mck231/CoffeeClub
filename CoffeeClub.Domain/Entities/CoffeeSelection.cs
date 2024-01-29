namespace CoffeeClub.Domain.Entities;

public class CoffeeSelection
{
    public Guid CoffeeGroupId { get; set; }
    public Guid CoffeeId { get; set; }
    public virtual CoffeeGroup CoffeeGroup { get; set; }
    public virtual Coffee Coffee { get; set; }
}