using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Exepenses.Delete;
using CashFlow.Application.UseCases.Exepenses.GetAll;
using CashFlow.Application.UseCases.Exepenses.GetById;
using CashFlow.Application.UseCases.Exepenses.Register;
using CashFlow.Application.UseCases.Exepenses.Reports.Excel;
using CashFlow.Application.UseCases.Exepenses.Reports.Pdf;
using CashFlow.Application.UseCases.Exepenses.Update;
using CashFlow.Application.UseCases.User.Login;
using CashFlow.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
            services.AddScoped<IGetExpenseByIDUseCase, GetExpenseByIdUseCase>();
            services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
            services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
            services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpenseReportExcelUseCase>();
            services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
            services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUseUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        }
    }
}
