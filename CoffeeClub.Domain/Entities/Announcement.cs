using CoffeeClub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{
    public class Announcement : AuditTableEntity
    {
        public Guid AnnouncementId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime AnnouncementDate { get; set; }
        public Guid TeamId { get; set; } // Team foreign key
        public virtual Team Team { get; set; } = default!; // Navigation property to Team
    }
}
