using SkiSchool.Application.Payments.Queries;
using SkiSchool.Application.Reports.Commands.CreateReport;

namespace SkiSchool.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildPaymentFile(IEnumerable<TimetableReportRecord> records);
}
