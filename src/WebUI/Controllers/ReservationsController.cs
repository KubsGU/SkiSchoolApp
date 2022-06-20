using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Reservations.Commands.CreateReservation;
using SkiSchool.Application.Reservations.Commands.DeleteReservation;
using SkiSchool.Application.Reservations.Queries;
using SkiSchool.Application.Reservations.Queries.GetReservations;
using SkiSchool.Application.Reservations.Queries.GetReservationById;


namespace SkiSchool.WebUI.Controllers;

public class ReservationsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ReservationDto>>> GetReservations([FromQuery] GetReservationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ReservationDto>> GetReservationById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetReservationByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateReservationCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteReservationCommand { Id = id });

        return NoContent();
    }
}