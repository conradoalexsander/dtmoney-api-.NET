using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

public class DtMoneyDbContext : DbContext
{
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    public DtMoneyDbContext(DbContextOptions<DtMoneyDbContext> options)
        : base(options) { }
}