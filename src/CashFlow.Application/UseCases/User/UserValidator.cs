using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.User
{
    public class UserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("The user Name Cannot Be Empty");
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("The user Name Cannot Be Empty")
                .EmailAddress()
                .WithMessage("Invalid Email");
            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
        }
    }
}
