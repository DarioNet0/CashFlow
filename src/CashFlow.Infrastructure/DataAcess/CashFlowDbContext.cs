using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAcess
{
    public class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database:cashflowdb;Uid=root;Pwd=Password@123;"; //sintaxe própria do mysql
            var serverVersion = new MySqlServerVersion(new Version(9, 0, 1));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}