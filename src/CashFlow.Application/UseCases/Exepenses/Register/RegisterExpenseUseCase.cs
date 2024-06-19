using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Application.UseCases.Exepenses.Register {
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestExpenseJson request)
        {
            Validate(request);
            return new ResponseRegisterExpenseJson();
        }
        private void Validate(RequestExpenseJson request) {
            var titleEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (titleEmpty) {
                throw new ArgumentException("The Title is required");
            }
            if (request.Amount <= 0) {
                throw new ArgumentException("The Amount must be greater than 0");
            }
            var result = DateTime.Compare(request.Date, DateTime.UtcNow);
            if (result  > 0) {
                throw new ArgumentException("Expenses cannot be for the furute");
            }
            var paymentTypeIsValid =  Enum.IsDefined(typeof(PaymentType), request.paymentType);
            if (paymentTypeIsValid == false) {
                throw new ArgumentException("Payment Type Is Not Valid");
            }
        }
    }
}
