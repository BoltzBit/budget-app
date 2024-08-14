using Budget.Core.Domain.Entities;
using Budget.Core.Domain.Enuns;
using Budget.Core.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budget.Infra.Configurations;

public class BudgetItemConfiguration : IEntityTypeConfiguration<BudgetItem>
{
    public void Configure(EntityTypeBuilder<BudgetItem> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Description)
            .HasMaxLength(Constants.MaxDescriptionLength)
            .HasColumnName("Description")
            .IsRequired();

        builder
            .Property(b => b.Type)
            .HasConversion(
                b => b.ToString(),
                b => (BudgetItemType)Enum.Parse(typeof(BudgetItemType), b));

        builder
            .Property(b => b.Price)
            .HasColumnName("Price")
            .HasPrecision(15,2)
            .IsRequired();

        builder.ToTable("BudgetItem", "budget");
    }
}
