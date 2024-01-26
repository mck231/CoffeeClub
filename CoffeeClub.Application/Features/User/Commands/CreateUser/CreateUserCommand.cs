using MediatR;

namespace CoffeeClub.Application.Features.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid TeamId { get; set; }
}