using AutoMapper;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Features.VotingSession.Commands.EditVotingSession;
using CoffeeClub.Application.Features.VottingSession.Commands.EditVotingSession;
using CoffeeClub.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.VotingSession.Commands.EditVotingSession
{
    public class EditVotingSessionCommandHandler : IRequestHandler<EditVotingSessionCommand, Unit>
    {
        private readonly IVotingSessionRepository _votingSessionRepository;
        private readonly IMapper _mapper;

        public EditVotingSessionCommandHandler(IVotingSessionRepository votingSessionRepository, IMapper mapper)
        {
            _votingSessionRepository = votingSessionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditVotingSessionCommand request, CancellationToken cancellationToken)
        {
            var votingSession = await GetVotingSessionById(request.VotingSessionId);
            var votingSessionVm = _mapper.Map<EditVotingSessionVm>(votingSession);

            await UpdateWinningCoffee(votingSessionVm, request.WinningCoffeeId);
            await UpdateTeam(votingSessionVm, request.TeamId);

            _mapper.Map(votingSessionVm, votingSession);
            await _votingSessionRepository.UpdateAsync(votingSession);

            return Unit.Value;
        }

        private async Task<Domain.Entities.VotingSession> GetVotingSessionById(Guid votingSessionId)
        {
            var votingSession = await _votingSessionRepository.GetByIdAsync(votingSessionId);
            if (votingSession == null)
            {
                throw new NotFoundException(nameof(VotingSession), votingSessionId);
            }
            return votingSession;
        }

        private async Task UpdateWinningCoffee(EditVotingSessionVm votingSession, Guid winningCoffeeId)
        {
            if (winningCoffeeId != Guid.Empty)
            {
                votingSession.WinningCoffeeId = winningCoffeeId;
            }
        }

        private async Task UpdateTeam(EditVotingSessionVm votingSession, Guid teamId)
        {
            if (teamId != Guid.Empty)
            {
                votingSession.TeamId = teamId;
            }
        }
    }
}
