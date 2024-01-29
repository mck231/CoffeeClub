using CoffeeClub.Domain.Common;
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
        public virtual ICollection<CoffeeSelection> CoffeeSelections { get; set; }
    }
}
