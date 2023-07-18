using CoffeeClub.Application.Features.VottingSession.Queries.GetVotingSession;
using CoffeeClub.Domain.Entities;
using MediatR;
using System;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession
{
    public class GetVotingSessionQuery : IRequest<VotingSessionVm>
    {
        public Guid VotingSessionId { get; set; }
    }
}
