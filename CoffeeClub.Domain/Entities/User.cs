using CoffeeClub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{   
    public class User : AuditTableEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsLeader { get; set; } = false;
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
