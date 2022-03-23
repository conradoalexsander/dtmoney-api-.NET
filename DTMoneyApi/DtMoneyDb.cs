using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

internal class DtMoneyDb : DbContext
{
    public DtMoneyDb(DbContextOptions<DtMoneyDb> options) 
        : base(options) { }

    public DbSet<FinancialTransaction> FinancialTransactions => Set<FinancialTransaction>();
}