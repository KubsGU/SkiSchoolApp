using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Reports.Commands.CreateReport;
using SkiSchool.Application.Reports.Commands.DeleteReport;
using SkiSchool.Application.Reports.Queries;
using SkiSchool.Application.Reports.Queries.GetReportById;
using SkiSchool.Application.Reports.Queries.GetReport;
using SkiSchool.Application.Reports.Commands.CreateRentalReport;
using System.Net.Http.Headers;

namespace SkiSchool.WebUI.Controllers;

public class ReportsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ReportDto>>> GetReports([FromQuery] GetReportQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ReportDto>> GetReportById(int id)
    {
        return await Mediator.Send(new GetReportByIdQuery { Id = id });
    }
    [HttpGet]
    [Route("download/{id}")]
    public async Task<IActionResult> DownloadReportById(int id)
    {
        var report = await Mediator.Send(new GetReportByIdQuery { Id = id });

        return Ok(report);
    }

    [HttpGet]
    [Route("downloadBlob/{id}")]
    public async Task<FileContentResult> DownloadReportBlobById(int id)
    {
        var report = await Mediator.Send(new GetReportByIdQuery { Id = id });

        return new FileContentResult(report.Data, "text/csv");
    }

    [HttpPost]
    [Route("timetable")]
    public async Task<ActionResult<int>> CreateTimetableReport(CreateTimetableReportCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPost]
    [Route("rental")]
    public async Task<ActionResult<int>> CreateRentalReport(CreateRentalReportCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteReportCommand { Id = id });

        return NoContent();
    }
}