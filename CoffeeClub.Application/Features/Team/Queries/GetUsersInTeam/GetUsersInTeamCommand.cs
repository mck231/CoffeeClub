using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Queries.GetUsersInTeam
{
    public class GetUsersInTeamCommand : IRequest<List<UserVm>>
    {
        public required Guid TeamId { get; set; }
    }
}
