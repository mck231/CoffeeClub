using CoffeeClub.Application.Contracts.Infrastructure;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        /// <summary>
        /// This exports data to CSV.
        /// Does not work on Brave Browser.
        /// </summary>
        /// <param name="jsonDataExportDtos"></param>
        /// <returns></returns>
        public byte[] ExportJsonDataToCsv(List<CoffeeDto> jsonDataExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(jsonDataExportDtos);
                }
            }
            return memoryStream.ToArray();
        }
    }
}
