using CashFlow.Application.UseCases.Exepenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestExpenseJson request)
        {
            try {
                var UseCase = new RegisterExpenseUseCase();
                var response = UseCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ArgumentException ex) {
                var errorResponse = new ResponseErrorJson(ex.Message);
                return BadRequest(errorResponse);
            }
            catch {
                var errorResponse = new ResponseErrorJson("unknown error");
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse.ErrorMessage);
            }
        }
    }
}
