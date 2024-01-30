using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSession
{
    public class VotingSessionVm
    {
        public Guid VotingSessionId { get; set; }
        public Guid CoffeeGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TeamId { get; set; }
    }
}
