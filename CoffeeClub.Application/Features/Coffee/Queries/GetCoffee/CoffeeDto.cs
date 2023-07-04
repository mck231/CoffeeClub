﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffee
{
    public class CoffeeDto
    {
        public Guid CoffeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PurchasingLink { get; set; }
        public string Size { get; set; }
        public string Origin { get; set; }
        public string RoastType { get; set; }
    }

}
