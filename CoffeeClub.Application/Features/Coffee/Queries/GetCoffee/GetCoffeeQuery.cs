using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffee
{
    public class GetCoffeeQuery : IRequest<CoffeeDetailsVm>
    {
        public Guid Id { get; set; }
    }

}
