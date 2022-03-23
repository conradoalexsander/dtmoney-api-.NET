using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

public class DtMoneyDbContext : DbContext
{
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    public DtMoneyDbContext(DbContextOptions<DtMoneyDbContext> options)
        : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<FinancialTransaction>()
            .Property(e => e.Type)
            .HasConversion<string>();
    }

}