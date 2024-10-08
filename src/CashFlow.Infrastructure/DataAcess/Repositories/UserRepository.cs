using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAcess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public UserRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.User.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User>? GetUserByEmail(string email)
        {
            return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task RegisterUser(User user)
        {
            await _dbContext.User.AddAsync(user);
        }
    }
}
