namespace CashFlow.Application.UseCases.Exepenses.Reports.Excel
{
    public interface IGenerateExpensesReportExcelUseCase
    {
        public Task<byte[]> Execute(DateOnly month);
    }
}
