using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles;

namespace RentACar.Persistence.Configurations.Vehicles;

internal sealed class FeatureConfiguration:BaseEntityConfiguration<Feature>
{
    public override void Configure(EntityTypeBuilder<Feature> builder)
    {
        base.Configure(builder);

        builder.ToTable("Features");

        builder.HasIndex(p => p.Name);

        builder.Property(p => p.Name)
               .HasMaxLength(500)
               .IsRequired();
    }
}
