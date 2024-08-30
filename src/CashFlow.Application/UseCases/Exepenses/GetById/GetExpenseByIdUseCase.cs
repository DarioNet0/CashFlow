
using AutoMapper;
using Cash.Flow.Exception;
using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Exepenses.GetById
{
    public class GetExpenseByIdUseCase : IGetExpenseByIDUseCase
    {
        private readonly IExpensesReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var result = await _repository.GetById(id);
            if (result is null)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }
            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}

