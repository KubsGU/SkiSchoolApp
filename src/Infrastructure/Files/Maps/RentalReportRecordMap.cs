using System.Globalization;
using CsvHelper.Configuration;
using SkiSchool.Application.Payments.Queries;
using SkiSchool.Application.Reports.Commands.CreateRentalReport;

namespace SkiSchool.Infrastructure.Files.Maps;
public class RentalReportRecordMap : ClassMap<RentalReportRecord>
{
    public RentalReportRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(p => p.Status).ConvertUsing(c => c.Status ? "Paid" : "Rejected");
        Map(p => p.Price).ConvertUsing(c => c.Price.ToString() + " PLN");
        Map(p => p.ClientFullName).Name("Client");
        Map(p => p.Equipment).ConvertUsing(c => string.Join(", ", c.Equipment.Select(e => e.Name)));
    }
}
