using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Equipments.Commands.CreateEquipment;
using SkiSchool.Application.Equipments.Commands.DeleteEquipment;
using SkiSchool.Application.Equipments.Queries;
using SkiSchool.Application.Equipments.Queries.GetEquipment;
using SkiSchool.Application.Equipments.Queries.GetEquipmentById;
using SkiSchool.Application.Equipments.Queries.GetEquipmentsByType;
using SkiSchool.Application.Equipments.Queries.GetEquipmentTypes;

namespace SkiSchool.WebUI.Controllers;

public class EquipmentsController : ApiControllerBase
{
    //ToDo: add as filtering to default endpoint
    [HttpGet]
    [Route("byTypes")]
    public async Task<ActionResult<PaginatedList<EquipmentDto>>> GetEquipmentsByType([FromQuery] GetEquipmentsByTypeQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<EquipmentDto>>> GetEquipment([FromQuery] GetEquipmentQuery query)
    {
        return await Mediator.Send(query);
    }

    //ToDo: Move to other controller
    [HttpGet]
    [Route("types")]
    public async Task<ActionResult<PaginatedList<string>>> GetTypes()
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetEqupimentTypesQuery());
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<EquipmentDto>> GetEquipmentById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetEquipmentByIdQuery{ Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateEquipmentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteEquipmentCommand { Id = id });

        return NoContent();
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await Mediator.Send(command);

    //    return NoContent();
    //}

    //[HttpPut("[action]")]
    //public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await Mediator.Send(command);

    //    return NoContent();
    //}


}
