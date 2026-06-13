using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class ContactConfiguration:BaseEntityConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        base.Configure(builder);

        builder.ToTable("Contacts");

        builder.Property(p => p.Name).HasMaxLength(250).IsRequired();

        builder.Property(p => p.Email).HasMaxLength(256).IsRequired();

        builder.Property(p => p.Subject).HasMaxLength(500).IsRequired();

        builder.Property(p => p.Message).HasColumnType("text").IsRequired();

        builder.Property(p => p.IsRead).HasDefaultValue(false).IsRequired();
    }
}
