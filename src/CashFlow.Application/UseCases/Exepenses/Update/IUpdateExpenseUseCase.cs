using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Exepenses.Update
{
    public interface IUpdateExpenseUseCase
    {
        Task Execute(long id , RequestExpenseJson request);
    }
}
