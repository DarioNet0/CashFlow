using CashFlow.Application.UseCases.Exepenses.Register;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validator.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuild.Build();
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
