using CoffeeClub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{
    public class Team : AuditTableEntity
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; } = string.Empty;        
        public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>(); 

    }
}
