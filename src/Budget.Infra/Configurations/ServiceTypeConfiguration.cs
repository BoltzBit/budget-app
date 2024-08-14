using Budget.Core.Domain.Entities;
using Budget.Core.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budget.Infra.Configurations;

public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .HasColumnName("Name")
            .HasMaxLength(Constants.MaxNameLength)
            .IsRequired();

        builder
            .Property(s => s.Description)
            .HasColumnName("Description")
            .HasMaxLength(Constants.MaxDescriptionLength)
            .IsRequired();

        builder.ToTable("ServiceType", "budget");
    }
}
