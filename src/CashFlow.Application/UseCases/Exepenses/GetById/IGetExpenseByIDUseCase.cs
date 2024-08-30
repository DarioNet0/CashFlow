using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Exepenses.GetById
{
    public interface IGetExpenseByIDUseCase
    {
        Task<ResponseExpenseJson> Execute(long id);
    };
}
