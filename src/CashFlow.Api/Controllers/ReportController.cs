using CashFlow.Application.UseCases.Exepenses.Reports.Excel;
using CashFlow.Application.UseCases.Exepenses.Reports.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetExcel(
            [FromServices] IGenerateExpensesReportExcelUseCase useCase,
            [FromHeader] string month
            )
        {
            if (!DateOnly.TryParseExact(month, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedMonth))
            {
                return BadRequest("Invalid date format. Please use the 'yyyy-MM-dd' format.");
            }

            byte[] file = await useCase.Execute(parsedMonth);
            
            if (file.Length > 0)
            {
                return File(file, MediaTypeNames.Application.Octet, "report.xlsx");
            }
            return NoContent();
        }

        [HttpGet("pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPdf(
            [FromServices] IGenerateExpensesReportPdfUseCase useCase,
            [FromQuery] string month
            )
        {
            if (!DateOnly.TryParseExact(month, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedMonth))
            {
                return BadRequest("Invalid date format. Please use the 'yyyy-MM-dd' format.");
            }
            byte[] file = await useCase.Execute(parsedMonth);

            if (file.Length > 0)
            {
                return File(file, MediaTypeNames.Application.Pdf, "report.pdf");
            }
            return NoContent();
        }
    }
}
