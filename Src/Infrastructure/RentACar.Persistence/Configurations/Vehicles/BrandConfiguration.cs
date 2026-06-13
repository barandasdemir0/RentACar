using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles;

namespace RentACar.Persistence.Configurations.Vehicles;

internal sealed class BrandConfiguration:BaseEntityConfiguration<Brand>
{
    public override void Configure(EntityTypeBuilder<Brand> builder)
    {
        base.Configure(builder);

        builder.ToTable("Brands");

        builder.HasIndex(p => p.Name);

        builder.Property(p => p.Name)
            .HasMaxLength(500)
            .IsRequired();
    }
}
