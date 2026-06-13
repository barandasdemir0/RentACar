using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles;

namespace RentACar.Persistence.Configurations.Vehicles;

internal sealed class CategoryConfiguration:BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("Categories");

        builder.HasIndex(p => p.Name);

        builder.Property(p => p.Name)
               .HasMaxLength(500)
               .IsRequired();
    }
}
