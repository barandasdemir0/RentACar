using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class ServiceConfiguration:BaseEntityConfiguration<Service>
{
    public override void Configure(EntityTypeBuilder<Service> builder)
    {
        base.Configure(builder);

        builder.ToTable("Services");

        builder.Property(p => p.Title).HasMaxLength(500).IsRequired();

        builder.Property(p => p.Description).HasColumnType("text").IsRequired();

        builder.Property(p => p.Icon).HasMaxLength(500).IsRequired();

        builder.Property(p => p.IconUrl).HasMaxLength(2048).IsRequired(false);
    }
}
