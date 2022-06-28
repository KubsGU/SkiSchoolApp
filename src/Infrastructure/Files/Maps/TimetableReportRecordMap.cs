using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using SkiSchool.Application.Reports.Commands.CreateReport;

namespace SkiSchool.Infrastructure.Files.Maps;
public class TimetableReportRecordMap : ClassMap<TimetableReportRecord>
{
    public TimetableReportRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(p => p.Status).ConvertUsing(c => c.Status ? "Paid" : "Rejected");
        Map(p => p.Price).ConvertUsing(c => c.Price.ToString() + " PLN");
        Map(p => p.ClientFullName).Name("Client");
        Map(p => p.TrainerFullName).Name("Trainer");
    }
}
