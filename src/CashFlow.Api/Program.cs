using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<CultureMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    //Cria escopo para acessar o servi�o de inje��o de dependencia, sem a necessidade de uma requisi��o
    await using var scope = app.Services.CreateAsyncScope();

    //Usa o servi�o de Inje��o de depend�ncia para acessar o dbContext
    await DataBaseMigration.MigrateDataBase(scope.ServiceProvider);


}