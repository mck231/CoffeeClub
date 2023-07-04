using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffeeList
{
    public class CoffeeDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string RoastType { get; set; }
    }

}
