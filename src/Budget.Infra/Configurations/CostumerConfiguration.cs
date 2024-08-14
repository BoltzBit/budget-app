using Budget.Core.Domain.Entities;
using Budget.Core.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budget.Infra.Configurations;

public class CostumerConfiguration : IEntityTypeConfiguration<Costumer>
{
    public void Configure(EntityTypeBuilder<Costumer> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .HasColumnName("Name")
            .HasMaxLength(Constants.MaxNameLength)
            .IsRequired();
        
        builder
            .Property(c => c.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(Constants.MaxPhoneLength)
            .IsRequired();

        builder
            .HasMany(c => c.Budgets)
            .WithOne(b => b.Costumer)
            .HasForeignKey(b => b.CostumerId);

        builder.ToTable("Costumer", "budget");
    }
}
