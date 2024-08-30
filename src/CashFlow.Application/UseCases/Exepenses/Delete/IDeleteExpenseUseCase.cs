namespace CashFlow.Application.UseCases.Exepenses.Delete
{
    public interface IDeleteExpenseUseCase
    {
        Task Execute(long id);
    }
}
