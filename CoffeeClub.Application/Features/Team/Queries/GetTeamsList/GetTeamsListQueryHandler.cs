using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using MediatR;

namespace CoffeeClub.Application.Features.Team.Queries.GetTeamsList;

public class GetTeamsListQueryHandler : IRequestHandler<GetTeamsListQuery, IEnumerable<TeamsListVm>>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamsListQueryHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }


    public async Task<IEnumerable<TeamsListVm>> Handle(GetTeamsListQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.ListAllAsync();
        return teams.Select(t => new TeamsListVm
        {
            TeamId = t.TeamId,
            Name = t.Name
        });
    }
}