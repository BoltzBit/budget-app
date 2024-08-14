using BudgetEntity = Budget.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Budget.Core.Domain.Enuns;

namespace Budget.Infra.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<BudgetEntity.Budget>
{
    public void Configure(EntityTypeBuilder<BudgetEntity.Budget> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Total)
            .HasColumnName("Total")
            .HasPrecision(15,2)
            .IsRequired();

        builder
            .Property(b => b.Deadline)
            .HasColumnName("Deadline")
            .IsRequired();

        builder
            .Property(b => b.Type)
            .HasConversion(
                b => b.ToString(),
                b => (BudgetType)Enum.Parse(typeof(BudgetType), b));

        builder
            .HasMany(b => b.BudgetItems)
            .WithOne(b => b.Budget)
            .HasForeignKey(b => b.BudgetId);


        builder.ToTable("Budget", "budget");
    }
}
