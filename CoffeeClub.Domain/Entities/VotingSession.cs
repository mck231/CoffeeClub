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
        public Guid CoffeeGroupId { get; set; } // Foreign key for CoffeeGroup
        public virtual CoffeeGroup CoffeeGroup { get; set; } = default!; // Navigation property to CoffeeGroup
        public virtual ICollection<GroupCoffeeVoting> GroupCoffeeVotings { get; set; } = new List<GroupCoffeeVoting>(); // GroupCoffeeVotings related to this session
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>(); // Votes cast in this session
        public Guid? WinningCoffeeId { get; set; }
        public virtual Coffee WinningCoffee { get; set; } = default!; // The coffee that won in this session
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; } = default!; // Navigation property to Team
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
