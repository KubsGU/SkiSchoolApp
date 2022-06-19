using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkiSchool.WebUI.Controllers;
public class ReportsController : Controller
{
    [HttpGet]
    [Route("types")]
    public async Task<ActionResult<IList<string>>> GetTypes()
    {
        return new List<string>() { "a", "b" };
        //return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<IList<string>>> GenerateReport([FromBody] string type, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
        //TODO implement
    }
}
