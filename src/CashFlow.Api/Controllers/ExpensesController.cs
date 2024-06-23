using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterdedExpenseJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestExpenseJson request)
    {
        var useCase = new RegisterExpenseUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
