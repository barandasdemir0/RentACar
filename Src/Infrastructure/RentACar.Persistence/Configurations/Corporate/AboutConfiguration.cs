using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class AboutConfiguration : BaseEntityConfiguration<About>
{
    public override void Configure(EntityTypeBuilder<About> builder)
    {
        //üst sınıfın kuralları
        base.Configure(builder);

        builder.ToTable("Abouts");

        builder.Property(p => p.Title).HasMaxLength(500).IsRequired();

        builder.Property(p => p.Description).HasColumnType("text").IsRequired();

        builder.Property(p => p.ImageUrl).HasMaxLength(2048).IsRequired(false);
    }
}
