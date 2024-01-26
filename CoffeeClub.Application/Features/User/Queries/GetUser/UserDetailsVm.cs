namespace CoffeeClub.Application.Features.User.Queries.GetUser;

public class UserDetailsVm
{
    public Guid UserId { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public bool IsLeader { get; set; }
    public Guid TeamId { get; set; }
}