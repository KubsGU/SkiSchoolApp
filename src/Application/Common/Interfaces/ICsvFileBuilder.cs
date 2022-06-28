using SkiSchool.Application.Payments.Queries;
using SkiSchool.Application.Reports.Commands.CreateRentalReport;
using SkiSchool.Application.Reports.Commands.CreateReport;

namespace SkiSchool.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTimetableReportFile(IEnumerable<TimetableReportRecord> records);

    byte[] BuildRentalReportFile(IEnumerable<RentalReportRecord> records);

}
