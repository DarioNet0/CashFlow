using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users
{
    public interface IUserWriteOnlyRepository
    {
        Task RegisterUser(User user);
    }
}
