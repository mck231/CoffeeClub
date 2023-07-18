using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Queries.GetTeam
{
    public class GetTeamQuery : IRequest<TeamVm>
    {
        public required Guid TeamId { get; set; }
    }
}
