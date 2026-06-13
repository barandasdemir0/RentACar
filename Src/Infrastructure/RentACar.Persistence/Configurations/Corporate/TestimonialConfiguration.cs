using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Corporate;

namespace RentACar.Persistence.Configurations.Corporate;

internal sealed class TestimonialConfiguration:BaseEntityConfiguration<Testimonial>
{
    public override void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        base.Configure(builder);

        builder.ToTable("Testimonials");

        builder.Property(p => p.Name).HasMaxLength(250).IsRequired();

        builder.Property(p => p.Title).HasMaxLength(500).IsRequired();

        builder.Property(p => p.Comment).HasColumnType("text").IsRequired();

        builder.Property(p => p.ImageUrl).HasMaxLength(2048).IsRequired(false);
    }
}
