using System.Globalization;
using CsvHelper;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Payments.Queries;
using SkiSchool.Application.Reports.Commands.CreateRentalReport;
using SkiSchool.Application.Reports.Commands.CreateReport;
using SkiSchool.Infrastructure.Files.Maps;

namespace SkiSchool.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTimetableReportFile(IEnumerable<TimetableReportRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TimetableReportRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
    public byte[] BuildRentalReportFile(IEnumerable<RentalReportRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<RentalReportRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}