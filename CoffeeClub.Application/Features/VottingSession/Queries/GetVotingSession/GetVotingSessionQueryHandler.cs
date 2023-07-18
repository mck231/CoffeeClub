using AutoMapper;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Features.VottingSession.Queries.GetVotingSession;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession
{
    public class GetVotingSessionQueryHandler : IRequestHandler<GetVotingSessionQuery, VotingSessionVm>
    {
        private readonly IVotingSessionRepository _votingSessionRepository;
        private readonly IMapper _mapper;

        public GetVotingSessionQueryHandler(IVotingSessionRepository votingSessionRepository, IMapper mapper)
        {
            _votingSessionRepository = votingSessionRepository;
            _mapper = mapper;
        }

        public async Task<VotingSessionVm> Handle(GetVotingSessionQuery request, CancellationToken cancellationToken)
        {
            var votingSession = await _votingSessionRepository.GetVotingSessionWithDetails(request.VotingSessionId);

            if (votingSession == null)
            {
                // Voting session not found, handle as needed (throw exception, return null, etc.)
                // For simplicity, let's throw a NotFoundException
                throw new NotFoundException(nameof(VotingSession), request.VotingSessionId);
            }

            var votingSessionVm = _mapper.Map<VotingSessionVm>(votingSession);

            return votingSessionVm;
        }
    }
}
