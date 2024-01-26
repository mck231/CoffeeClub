using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using MediatR;

namespace CoffeeClub.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IAsyncRepository<Domain.Entities.User> _userRepository;

    public UpdateUserCommandHandler(IAsyncRepository<Domain.Entities.User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.UserId);
        if (existingUser is null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        existingUser.Name = request.Name;
        existingUser.Email = request.Email;
        existingUser.TeamId = request.TeamId;
        existingUser.IsLeader = request.IsLeader;
        existingUser.LastModifiedDate = DateTime.Now;

        await _userRepository.UpdateAsync(existingUser);

        return existingUser.UserId;

    }
}