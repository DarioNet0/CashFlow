using AutoMapper;
using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.User.Register
{
    public class RegisterUseUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _encripter;
        private readonly IUserReadOnlyRepository _UserReadOnlyrepositoy;
        private readonly IUserWriteOnlyRepository _UserWriteonlyrepositoy;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessTokenGenerator _tokenGenerator;
        public RegisterUseUseCase(
            IMapper mapper,
            IPasswordEncripter encripter,
            IUserReadOnlyRepository repository,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IAccessTokenGenerator tokenGenerator
            )
        {
            _mapper = mapper;
            _encripter = encripter;
            _UserReadOnlyrepositoy = repository;
            _UserWriteonlyrepositoy = userWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<ResponseRegisterUserJson> execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _encripter.Encrypt(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            await _UserWriteonlyrepositoy.RegisterUser(user);

            await _unitOfWork.Commit();

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.GenerateToken(user)
            };
        }
        private async Task Validate(RequestRegisterUserJson request)
        {
            var validator = new UserValidator();

            var result = validator.Validate(request);

            var emailExists = await _UserReadOnlyrepositoy.ExistActiveUserWithEmail(request.Email);

            if (emailExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Email já cadastrado"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
