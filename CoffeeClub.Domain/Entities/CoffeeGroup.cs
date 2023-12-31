﻿using CoffeeClub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{
    public class CoffeeGroup: AuditTableEntity
    {
        public Guid CoffeeGroupId { get; set; }
        public virtual ICollection<VotingSession> VotingSessions { get; set; } = new List<VotingSession>();
        public virtual ICollection<GroupCoffeeVoting> GroupCoffeeVotings { get; set; } = new List<GroupCoffeeVoting>();
    }
}
