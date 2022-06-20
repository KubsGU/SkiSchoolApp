using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Clients.Commands.DeleteClient;
using SkiSchool.Application.Clients.Queries;
using SkiSchool.Application.Clients.Queries.GetClientById;
using SkiSchool.Application.Clients.Queries.GetClient;
using SkiSchool.Application.Clients.Commands.CreateClient;

namespace SkiSchool.WebUI.Controllers;

public class ClientsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ClientDto>>> GetClients([FromQuery] GetClientQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ClientDto>> GetClientById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetClientByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateClientCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteClientCommand { Id = id });

        return NoContent();
    }
}