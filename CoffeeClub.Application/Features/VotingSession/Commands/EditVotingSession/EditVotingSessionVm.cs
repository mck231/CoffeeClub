using CoffeeClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.VottingSession.Commands.EditVotingSession
{
    public class EditVotingSessionVm
    {
        public Guid CoffeeGroupId { get; set; }
       // public ICollection<GroupCoffeeVoting> GroupCoffeeVotings { get; set; } 
        public ICollection<Vote> Votes { get; set; }
        public Guid? WinningCoffeeId { get; set; }
        public Guid TeamId { get; set; }       
        public DateTime EditDate { get; set; }
    }
}
