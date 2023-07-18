using CoffeeClub.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Queries.GetUsersInTeam
{
    public class GetUsersInTeamCommandHandler : IRequestHandler<GetUsersInTeamCommand, List<UserVm>>
    {
        private readonly ITeamRepository _teamRepository;

        public GetUsersInTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

       

        async Task<List<UserVm>> IRequestHandler<GetUsersInTeamCommand, List<UserVm>>.Handle(GetUsersInTeamCommand request, CancellationToken cancellationToken)
        {
            var users = await _teamRepository.GetUsersInTeam(request.TeamId);

            var userVms = users.Select(user => new UserVm
            {
                Name = user.Name,
                Email = user.Email,
                IsLeader = user.IsLeader
            }).ToList();

            return userVms;
        }
    }
}
