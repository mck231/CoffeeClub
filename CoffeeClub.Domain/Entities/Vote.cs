using CoffeeClub.Domain.Common;
using CoffeeClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{
    public class Vote : AuditTableEntity
    {
        public Guid VoteId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid CoffeeId { get; set; }
        public virtual Coffee Coffee { get; set; }
        public Guid VotingSessionId { get; set; }
        public virtual VotingSession VotingSession { get; set; }
    }
}
