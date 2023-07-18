using AutoMapper;
using CoffeeClub.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.VottingSession.Commands.CreateVotingSession
{
    public class CreateVotingSessionCommandHandler : IRequestHandler<CreateVotingSessionCommand, Guid>
    {
        private readonly IVotingSessionRepository _votingSessionRepository;
        private readonly IMapper _mapper;

        public CreateVotingSessionCommandHandler(IVotingSessionRepository votingSessionRepository, IMapper mapper)
        {
            _votingSessionRepository = votingSessionRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateVotingSessionCommand request, CancellationToken cancellationToken)
        {
            var votingSession = new Domain.Entities.VotingSession
            {
                CoffeeGroupId = request.CoffeeGroupId,
                TeamId = request.TeamId,
                WinningCoffeeId = null,

            };

            await _votingSessionRepository.AddAsync(votingSession);

            return votingSession.VotingSessionId;
        }
    }
}
