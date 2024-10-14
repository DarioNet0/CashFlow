using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    class RequestRegisterUserJsonBuild
    {
        public static RequestRegisterUserJson Builder(RequestRegisterUserJson request)
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(user => user.Name, faker => faker.Person.FirstName)
                .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
                .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
        }
    }
}
