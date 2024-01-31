using MediatR;

namespace CoffeeClub.Application.Features.Team.Queries.GetTeamsList;

public class GetTeamsListQuery : IRequest<IEnumerable<TeamsListVm>>
{
    
}