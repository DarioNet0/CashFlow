using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAcess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        public void Add(Expense expense)
        {
            var dbContext = new CashFlowDbContext();
            dbContext.Expenses.Add(expense);
            dbContext.SaveChanges();
        }
    }
}
