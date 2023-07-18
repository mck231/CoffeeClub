using System;
using MediatR;

namespace CoffeeClub.Application.Features.VotingSession.Commands.EditVotingSession
{
    public class EditVotingSessionCommand : IRequest<Unit>
    {
        public Guid VotingSessionId { get; set; }
        public Guid WinningCoffeeId { get; set; }
        public Guid TeamId { get; set; }
    }
}
