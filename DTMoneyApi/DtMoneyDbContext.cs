using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

public class DtMoneyDbContext : DbContext
{
    public DtMoneyDbContext(DbContextOptions<DtMoneyDbContext> options) 
        : base(options) { }

    public DbSet<FinancialTransaction> FinancialTransactions => Set<FinancialTransaction>();
}