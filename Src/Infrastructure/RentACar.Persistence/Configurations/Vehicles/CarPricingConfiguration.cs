using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Persistence.Configurations.Vehicles;

internal sealed class CarPricingConfiguration:BaseEntityConfiguration<CarPricing>
{
    public override void Configure(EntityTypeBuilder<CarPricing> builder)
    {
        base.Configure(builder);

        builder.ToTable("CarPricings");

        builder.Property(p => p.Amount)
               .HasColumnType("numeric(18,2)")
               .IsRequired();

        builder.HasIndex(p => new
        {
            p.CarId,
            p.PricingId
        }).IsUnique();

        //araba silindiğinde arabaya ait tüm kayıtların silinmesi
        builder.HasOne(p => p.Car)
            .WithMany(p => p.Pricings)
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        //bir fiyat bir çok araba için kullanılıyorsa silinmez
        builder.HasOne(p => p.Pricing)
            .WithMany()
            .HasForeignKey(p => p.PricingId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
