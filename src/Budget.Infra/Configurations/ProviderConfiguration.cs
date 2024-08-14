using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Budget.Core.Domain.Entities;
using Budget.Core.Domain.Utils;

namespace Budget.Infra.Configurations;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasColumnName("Name")
            .HasMaxLength(Constants.MaxNameLength)
            .IsRequired();

        builder
            .Property(p => p.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(Constants.MaxPhoneLength)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasColumnName("Description")
            .HasMaxLength(Constants.MaxDescriptionLength)
            .IsRequired();

        builder
            .HasMany(p => p.Budgets)
            .WithOne(b => b.Provider)
            .HasForeignKey(b => b.ProviderId);

        builder
            .HasMany(p => p.Services)
            .WithOne(b => b.Provider)
            .HasForeignKey(b => b.ProviderId);

        builder.ToTable("Provider", "budget");
    }
}
