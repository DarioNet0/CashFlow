using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Exepenses.Reports.Excel
{
    public class GenerateExpenseReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        private const string CURRENCY_SYMBOL = "$";
        private readonly IExpensesReadOnlyRepository _repository;
        public GenerateExpenseReportExcelUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
            List<Expense> expenses = await _repository.FilterByMonth(month);

            if (expenses.Count == 0)
            {
                return [0]; 
            }

           using var workBook = new XLWorkbook();

            workBook.Author = "Dário Oliveira";
            workBook.Style.Font.FontSize = 12;
            workBook.Style.Font.FontName = "Times New Roman";

            var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(workSheet);
            var raw = 2;
            foreach (var expense in expenses)
            {
                workSheet.Cell($"A{raw}").Value = expense.Title;
                workSheet.Cell($"B{raw}").Value = expense.Date;
                workSheet.Cell($"C{raw}").Value = ConvertPaymentType(expense.PaymentType);

                workSheet.Cell($"D{raw}").Value = expense.Amount;
                workSheet.Cell($"D{raw}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##";

                workSheet.Cell($"E{raw}").Value = expense.Description;

                raw++;
            }

            workSheet.Columns().AdjustToContents();

            var file = new MemoryStream();
            workBook.SaveAs(file);

            return file.ToArray();
        }

        private string ConvertPaymentType(Domain.Enums.PaymentType payment)
        {
            return payment switch
            {
                Domain.Enums.PaymentType.Cash => "Dinheiro",
                Domain.Enums.PaymentType.CreditCard => "Cartão de Crédito",
                Domain.Enums.PaymentType.DebitCard => "Cartão de Débito",
                Domain.Enums.PaymentType.EletronicTransfer => "Transferência Bancária",
                _ => string.Empty
            };
        }
        private void InsertHeader(IXLWorksheet workSheet) 
        {
            workSheet.Cell("A1").Value = "Título";
            workSheet.Cell("B1").Value = "Data";
            workSheet.Cell("C1").Value = "Tipo de Pagamento";
            workSheet.Cell("D1").Value = "Valor";
            workSheet.Cell("E1").Value = "Descrição";
                
            workSheet.Cells("A1:E1").Style.Font.Bold = true;
                
            workSheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#0C65EE");
                
            workSheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            workSheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            workSheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            workSheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                
            workSheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        }
    }
}