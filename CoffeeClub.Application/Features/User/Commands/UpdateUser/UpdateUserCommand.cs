using MediatR;

namespace CoffeeClub.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Guid>
{
    public required Guid UserId { get; set; } 
    public string Name { get; set; } 
    public string Email { get; set; } 
    public bool IsLeader { get; set; }
    public Guid TeamId { get; set; }
}