using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Team.Queries.GetTeam
{
    public class TeamVm
    {
        public string Name { get; set; }
        public List<TeamMembersVm> Members {get; set; }
    }
}
