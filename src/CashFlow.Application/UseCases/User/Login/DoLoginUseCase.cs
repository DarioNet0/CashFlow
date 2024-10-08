using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;

namespace CashFlow.Application.UseCases.User.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        public DoLoginUseCase(
            IUserReadOnlyRepository userReadOnlyRepository,
            IPasswordEncripter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _passwordEncripter = passwordEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
            _accessTokenGenerator = accessTokenGenerator;
        }
        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var user = await _userReadOnlyRepository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new ErrorOnLoginException();
            }

            var passwordMatch = _passwordEncripter.verifyPassword(request.Password, user.Password);

            if (passwordMatch is false)
            {
                throw new ErrorOnLoginException();
            }

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.GenerateToken(user)
            };
        }
    }
}
