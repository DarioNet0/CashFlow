using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAcess.Repositories
{
    internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpenseUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Expense expense)
        {
            await _dbContext.Expense.AddAsync(expense);
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _dbContext.Expense.AsNoTracking().ToListAsync();
        }
        async Task<Expense?> IExpensesReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Expense.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        async Task<Expense?> IExpenseUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Expense.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Expense.FirstOrDefaultAsync(e => e.Id == id);
            if (result is null)
            {
                return false;
            }
            _dbContext.Expense.Remove(result);
            return true;
        }
        public void Update(Expense expense)
        {
            _dbContext.Expense.Update(expense);
        }

        public async Task<List<Expense>> FilterByMonth(DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

            return await _dbContext
                .Expense
                .AsNoTracking()
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .OrderBy(e => e.Date)
                .ToListAsync();

        }
    }
}