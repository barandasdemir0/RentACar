using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Persistence.Configurations.Vehicles.Car;

internal sealed class CarFeatureConfiguration:BaseEntityConfiguration<CarFeature>
{
    public override void Configure(EntityTypeBuilder<CarFeature> builder)
    {
        base.Configure(builder);

        builder.ToTable("CarFeatures");

        builder.Property(p => p.Available).HasDefaultValue(true).IsRequired();

        //bir arabaya bir özellik sadece 1 kere tanımlanır
        builder.HasIndex(p => new
        {
            p.CarId,
            p.FeatureId
        }).IsUnique();

        builder.HasOne(p => p.Car) //her Feature bir Car'a aittir
            .WithMany(p => p.Features) //bir Car'ın birçok Feature'ı vardır
            .HasForeignKey(p => p.CarId) // Feature tablosundaki FK
            .OnDelete(DeleteBehavior.Cascade); // Car silinirse bağlı Features da silinir

        builder.HasOne(p => p.Feature)
            .WithMany()
            .HasForeignKey(p => p.FeatureId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}
