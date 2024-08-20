using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Exepenses.GetAll
{
    public interface IGetAllExpensesUseCase
    {
        Task<ResponseExpensesJson> Execute();
    }
}
