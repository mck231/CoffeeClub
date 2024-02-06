using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Contracts.Infrastructure
{
    public interface ICsvExporter<T>
    {
        byte[] ExportJsonDataToCsv(List<T> jsonDataExportDtos);

    }
}
