using Budget.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Budget.Infra;

public class BudgetDbContext : DbContext
{
    public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
        :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach(var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if(entry.State is EntityState.Added)
            {
                entry.Entity.SetCreatedAt(DateTime.UtcNow);
            }

            if(entry.State is EntityState.Modified)
            {
                entry.Entity.SetUpdatedAt(DateTime.UtcNow);
            }
        }

        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
