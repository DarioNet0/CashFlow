using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Exepenses.Reports.Pdf
{
    public interface IGenerateExpensesReportPdfUseCase
    {
        public Task<byte[]> Execute(DateOnly month);
    }
}
