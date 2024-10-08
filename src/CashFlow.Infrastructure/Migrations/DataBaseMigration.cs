using CashFlow.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public static async Task MigrateDataBase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
