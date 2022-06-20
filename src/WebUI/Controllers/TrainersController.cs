using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Trainers.Commands.CreateTrainer;
using SkiSchool.Application.Trainers.Commands.DeleteTrainer;
using SkiSchool.Application.Trainers.Queries;
using SkiSchool.Application.Trainers.Queries.GetTrainer;
using SkiSchool.Application.Trainers.Queries.GetTrainerById;


namespace SkiSchool.WebUI.Controllers;

public class TrainersController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<TrainerDto>>> GetTrainers([FromQuery] GetTrainerQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<TrainerDto>> GetTrainerById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetTrainerByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTrainerCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTrainerCommand { Id = id });

        return NoContent();
    }
}