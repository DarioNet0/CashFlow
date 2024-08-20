using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Exepenses.Register
{
    public interface IRegisterExpenseUseCase
    {
        Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request);
    }
}
