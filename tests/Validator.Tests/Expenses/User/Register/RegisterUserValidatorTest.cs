using CashFlow.Application.UseCases.User;
using CommonTestUtilities.Requests;

namespace Validator.Tests.Expenses.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Succes()
        {
            //Arrange
            var validator = new UserValidator();
            var request = RequestRegisterExpenseJsonBuild.Build();

            //Act
            validator.Validate
        }
    }
}
