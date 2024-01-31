using CoffeeClub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{
    public class VotingSession : AuditTableEntity
    {
        public Guid VotingSessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid CoffeeGroupId { get; set; }
        public virtual CoffeeGroup CoffeeGroup { get; set; } = default!;
    }
}
