using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Timetables.Commands.CreateTimetable;
using SkiSchool.Application.Timetables.Commands.DeleteTimetable;
using SkiSchool.Application.Timetables.Queries;
using SkiSchool.Application.Timetables.Queries.GetTimetable;
using SkiSchool.Application.Timetables.Queries.GetTimetableById;


namespace SkiSchool.WebUI.Controllers;

public class TimetablesController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<TimetableDto>>> GetTimetables([FromQuery] GetTimetableQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<TimetableDto>> GetTimetableById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetTimetableByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTimetableCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTimetableCommand { Id = id });

        return NoContent();
    }
}