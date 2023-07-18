using CoffeeClub.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand>
    {
        private readonly IAsyncRepository<Domain.Entities.Team> _teamRepository;

        public CreateTeamCommandHandler(IAsyncRepository<Domain.Entities.Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Domain.Entities.Team()
            {
                TeamId = Guid.NewGuid(),
                Name = request.Name
            };
            await _teamRepository.AddAsync(team);
        }
    }
}
