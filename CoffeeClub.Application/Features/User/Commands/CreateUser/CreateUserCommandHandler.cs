using CoffeeClub.Application.Contracts.Persistence;
using MediatR;

namespace CoffeeClub.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IAsyncRepository<Domain.Entities.User> _userRepository;

    public CreateUserCommandHandler(IAsyncRepository<Domain.Entities.User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User
        {
            UserId = Guid.NewGuid(), 
            Name = command.Name,
            Email = command.Email,
            IsLeader = false,
            TeamId = command.TeamId
            
        };
        await _userRepository.AddAsync(user);
        return user.UserId;
    }
}