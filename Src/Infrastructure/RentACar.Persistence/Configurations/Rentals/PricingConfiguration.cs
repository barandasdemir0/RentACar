using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Rentals;

namespace RentACar.Persistence.Configurations.Rentals;

internal sealed class PricingConfiguration:BaseEntityConfiguration<Pricing>
{
    public override void Configure(EntityTypeBuilder<Pricing> builder)
    {
        base.Configure(builder);

        builder.ToTable("Pricings");

        builder.Property(p => p.Name)
               .HasMaxLength(500)
               .IsRequired();
    }
}
