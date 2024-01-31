using AutoMapper;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Application.Exceptions;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession;
using MediatR;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionsByTeam;

public class GetVotingSessionsByTeamQueryHandler : IRequestHandler<GetVotingSessionsByTeamQuery, TeamVotingSessionsVm>
{
    private readonly IVotingSessionRepository _votingSessionRepository;
    private readonly IMapper _mapper;

    public GetVotingSessionsByTeamQueryHandler(IVotingSessionRepository votingSessionRepository, IMapper mapper)
    {
        _votingSessionRepository = votingSessionRepository;
        _mapper = mapper;
    }
    public async Task<TeamVotingSessionsVm> Handle(GetVotingSessionsByTeamQuery request, CancellationToken cancellationToken)
    {
        var votingSession = await _votingSessionRepository.GetTeamVotingSessions(request.TeamId);

        if (votingSession == null)
        {
            throw new NotFoundException(nameof(VotingSession), request.TeamId);
        }

        var votingSessionVm = _mapper.Map<TeamVotingSessionsVm>(votingSession);

        return votingSessionVm;
    }
}