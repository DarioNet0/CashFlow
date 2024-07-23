using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterExpenseJsonBuild
    {
        public static RequestRegisterExpenseJson Build()
        {
            var faker = new Faker();
            return new Faker<RequestRegisterExpenseJson>()
                .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
                .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(r => r.Date, faker => faker.Date.Past())
                .RuleFor(r => r.paymentType, faker => faker.PickRandom<PaymentType>())
                .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 100));
        }
    }
}
