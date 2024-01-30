using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.VottingSession.Commands.CreateVotingSession
{
    public class CreateVotingSessionCommand : IRequest<Guid>
    {
        public Guid CoffeeGroupId { get; set; }
        public Guid TeamId { get; set; }
    }
}
