using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Rentals.Commands.CreateRental;
using SkiSchool.Application.Rentals.Commands.DeleteRental;
using SkiSchool.Application.Rentals.Queries;
using SkiSchool.Application.Rentals.Queries.GetRentals;
using SkiSchool.Application.Rentals.Queries.GetRentalById;


namespace SkiSchool.WebUI.Controllers;

public class RentalsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<RentalDto>>> GetRentals([FromQuery] GetRentalQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<RentalDto>> GetRentalById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetRentalByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRentalCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteRentalCommand { Id = id });

        return NoContent();
    }
}