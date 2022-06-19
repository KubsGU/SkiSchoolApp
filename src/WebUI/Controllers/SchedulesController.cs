using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Schedules.Commands.CreateSchedule;
using SkiSchool.Application.Schedules.Commands.DeleteSchedule;
using SkiSchool.Application.Schedules.Queries;
using SkiSchool.Application.Schedules.Queries.GetSchedules;
using SkiSchool.Application.Schedules.Queries.GetScheduleById;


namespace SkiSchool.WebUI.Controllers;

public class SchedulesController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ScheduleDto>>> GetSchedules([FromQuery] GetScheduleQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ScheduleDto>> GetScheduleById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetScheduleByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateScheduleCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteScheduleCommand { Id = id });

        return NoContent();
    }
}