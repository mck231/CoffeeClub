using CoffeeClub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Domain.Entities
{
    public class Payment : AuditTableEntity
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
