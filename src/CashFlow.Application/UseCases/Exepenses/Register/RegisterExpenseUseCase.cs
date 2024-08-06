using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;


namespace CashFlow.Application.UseCases.Exepenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);
            var entity = new Expense
            {
                Amount = request.Amount,
                Date = request.Date,
                Description = request.Description,
                PaymentType = (Domain.Enums.PaymentType)request.paymentType,
                Title = request.Title,
            };
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