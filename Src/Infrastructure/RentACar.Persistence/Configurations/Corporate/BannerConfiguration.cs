using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class BannerConfiguration:BaseEntityConfiguration<Banner>
{
    public override void Configure(EntityTypeBuilder<Banner> builder)
    {
        base.Configure(builder);


        builder.ToTable("Banners");

        builder.Property(p => p.Title).HasMaxLength(500).IsRequired();

        builder.Property(p => p.Description).HasColumnType("text").IsRequired();

        builder.Property(p => p.VideoDescription).HasMaxLength(500).IsRequired(false);

        builder.Property(p => p.VideoUrl).HasMaxLength(2048).IsRequired(false);
    }
}
