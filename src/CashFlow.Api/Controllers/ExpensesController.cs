using CashFlow.Application.UseCases.Exepenses.Register;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestExpenseJson request)
        {
            var UseCase = new RegisterExpenseUseCase();
            var response = UseCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
