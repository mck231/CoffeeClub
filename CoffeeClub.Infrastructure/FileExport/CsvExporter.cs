using CoffeeClub.Application.Contracts.Infrastructure;
using CsvHelper;
using System.Globalization;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionExcelFileQuery;
namespace CoffeeClub.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter<VoteSummaryDto>
    {
       
        /// <summary>
        /// This exports data to CSV.
        /// Does not work on Brave Browser.
        /// </summary>
        /// <param name="jsonDataExportDtos"></param>
        /// <returns></returns>
        public byte[] ExportJsonDataToCsv(List<VoteSummaryDto> jsonDataExportDtos)
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
