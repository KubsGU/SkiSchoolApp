using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Reports.Commands.CreateReport;
using SkiSchool.Application.Reports.Commands.DeleteReport;
using SkiSchool.Application.Reports.Queries;
using SkiSchool.Application.Reports.Queries.GetReportById;
using SkiSchool.Application.Reports.Queries.GetReport;

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
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetReportByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateReportCommand command)
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