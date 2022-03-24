using DTMoney.Api.Data;
using DTMoney.Api.Model;
using Microsoft.EntityFrameworkCore;

public class DtMoneyDbContext : DbContext
{
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    public DtMoneyDbContext(DbContextOptions<DtMoneyDbContext> options)
        : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleCreatedAtAndUpdatedAt();

        return base.SaveChangesAsync();
    }

    public override int SaveChanges()
    {
        HandleCreatedAtAndUpdatedAt();

        return base.SaveChanges();
    }

    private void HandleCreatedAtAndUpdatedAt()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }
    }
}