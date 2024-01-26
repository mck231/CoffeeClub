using CoffeeClub.Application.Features.Team.Queries.GetUsersInTeam;
using MediatR;

namespace CoffeeClub.Application.Features.User.Queries.GetUser;

public class GetUserQuery : IRequest<UserDetailsVm>
{
    public required Guid UserId { get; set; }
}