using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        // Fix this, probably needs a delegate or something??? --Marco Cabrera
        byte[] ExportJsonDataToCsv(List<CoffeeDto> jsonDataExportDtos);

    }
}
