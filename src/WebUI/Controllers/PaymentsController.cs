using Microsoft.AspNetCore.Mvc;
using SkiSchool.Application.Common.Models;
using SkiSchool.Application.Payments.Commands.CreatePayment;
using SkiSchool.Application.Payments.Commands.DeletePayment;
using SkiSchool.Application.Payments.Queries;
using SkiSchool.Application.Payments.Queries.GetPayments;
using SkiSchool.Application.Payments.Queries.GetPaymentById;


namespace SkiSchool.WebUI.Controllers;

public class PaymentsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<PaymentDto>>> GetPayments([FromQuery] GetPaymentQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
    {
        //return new List<string>() { "a","b"};
        return await Mediator.Send(new GetPaymentByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePaymentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePaymentCommand { Id = id });

        return NoContent();
    }
}