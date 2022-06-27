using System.Globalization;
using CsvHelper.Configuration;
using SkiSchool.Application.Payments.Queries;

namespace SkiSchool.Infrastructure.Files.Maps;
public class PaymentRecordMap : ClassMap<PaymentDto>
{
    public PaymentRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(p => p.Status).ConvertUsing(c => c.Status ? "Yes" : "No");
    }
}
