using AutoMapper;
using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using System.Runtime.CompilerServices;


namespace CashFlow.Application.UseCases.Exepenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase 
    {
        private readonly IExpensesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        public RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _autoMapper = mapper;
        }
        public async Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);
            var entity = _autoMapper.Map<Expense> (request);
            await _repository.Add(entity);
            await _unitOfWork.Commit();
            return _autoMapper.Map<ResponseRegisterExpenseJson>(entity);
        }
        private void Validate(RequestRegisterExpenseJson request) {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false) {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }            
        }
    }
}