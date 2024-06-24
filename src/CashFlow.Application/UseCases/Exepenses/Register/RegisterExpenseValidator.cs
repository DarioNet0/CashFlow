using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Exepenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson> {
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The Title is required");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The Amount must be greater than 0");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.Now).WithMessage("Expenses cannot be for the furute");
        RuleFor(expense => expense.paymentType).IsInEnum().WithMessage("Payment Type Is Not Valid");
    }
}
