using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest
    {
        public string Name { get; set; }
    }
}
