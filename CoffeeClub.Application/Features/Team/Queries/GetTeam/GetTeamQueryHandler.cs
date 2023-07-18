using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Queries.GetTeam
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, TeamVm>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamVm> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.TeamId);

            if (team == null)
            {
                throw new NotFoundException(nameof(Team), request.TeamId);
            }

            var teamVm = new TeamVm
            {
                Name = team.Name,
            };

            return teamVm;
        }
        
    }
}
