using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Queries.GetCoffeeList
{
    public class GetCoffeeListQuery : IRequest<CoffeeListVm>
    {
        public required List<Guid> CoffeeGuids { get; set; }
    }

}
