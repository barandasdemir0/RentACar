using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class SocialMediaConfiguration:BaseEntityConfiguration<SocialMedia>
{
    public override void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        base.Configure(builder);

        builder.ToTable("SocialMedias");

        builder.Property(p => p.Name).HasMaxLength(250).IsRequired();

        builder.Property(p => p.Url).HasMaxLength(2048).IsRequired();

        builder.Property(p => p.Icon).HasMaxLength(500).IsRequired();
    }
}
