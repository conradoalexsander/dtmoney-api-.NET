using DTMoney.Api.Extensions.Configuration;
using DTMoney.Api.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorsConfiguration();

builder.Services.AddDatabaseConfiguration();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddJsonSerializerConfiguration();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddFluentValidationConfiguration();

builder.Services.RegisterRepositories();



var app = builder.Build();
app.UseCorsConfiguration();

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();


app.UseFinancialTransactionRoutes();

app.Run();
