using DTMoney.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DTMoney.Api.Extensions.Configuration
{
    public static class DataConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<DtMoneyDbContext>(options =>
                options.UseInMemoryDatabase(nameof(DtMoneyDbContext)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();

            return services;
        }
    }
}
