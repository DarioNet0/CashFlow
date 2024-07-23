using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Exepenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);
            return new ResponseRegisterExpenseJson();
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