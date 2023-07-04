using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffee
{
    public class CoffeeDetailsVm
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PurchasingLink { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string RoastType { get; set; } = string.Empty;
    }
}
