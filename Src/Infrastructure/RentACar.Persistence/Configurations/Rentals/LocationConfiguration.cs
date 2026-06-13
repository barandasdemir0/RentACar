using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Rentals;

namespace RentACar.Persistence.Configurations.Rentals;

internal sealed class LocationConfiguration:BaseEntityConfiguration<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        base.Configure(builder);

        builder.ToTable("Locations");

        builder.Property(p => p.Name).HasMaxLength(500).IsRequired();

        builder.HasIndex(p => p.Name);

        builder.Property(p => p.IsActive).HasDefaultValue(false).IsRequired();
    }
}
