using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class FooterAddressConfiguration:BaseEntityConfiguration<FooterAddress>
{
    public override void Configure(EntityTypeBuilder<FooterAddress> builder)
    {
        base.Configure(builder);

        builder.ToTable("FoterAddresses");

        builder.Property(p => p.Description).HasColumnType("test").IsRequired();

        builder.Property(p => p.Address).HasMaxLength(2000).IsRequired();

        builder.Property(p => p.Mail).HasMaxLength(256).IsRequired();

        builder.Property(p => p.Phone).HasMaxLength(50).IsRequired();
    }
}
