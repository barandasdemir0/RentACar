using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Persistence.Configurations.Vehicles;


internal sealed class CarConfiguration:BaseEntityConfiguration<Car>
{
    public override void Configure(EntityTypeBuilder<Car> builder)
    {
        base.Configure(builder);

        builder.ToTable("Cars");

        builder.Property(p => p.Model).HasMaxLength(500).IsRequired();

        //enum durumlarını 10 20 30 yerine available rented gibi çektik
        builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(50).IsRequired();

        //value objectleri tablo olarak değilde kolon kolon olarak almamıza sağlayan komut

        builder.OwnsOne(p => p.Images, navigationBuilder =>
        {
            navigationBuilder.Property(i => i.CoverImageUrl)
            .HasColumnName("CoverImageUrl")
            .HasMaxLength(2048)
            .IsRequired();

            navigationBuilder.Property(i => i.BigImageUrl)
            .HasColumnName("BigImageUrl")
            .HasMaxLength(2048)
            .IsRequired();
        });

        builder.OwnsOne(p => p.Specifications, navigationBuilder =>
        {
            navigationBuilder.Property(s => s.Kilometer).HasColumnName("Kilometer").IsRequired();

            navigationBuilder.Property(s => s.Seats).HasColumnName("Seats").IsRequired();

            navigationBuilder.Property(s => s.Luggage).HasColumnName("Luggage").IsRequired();

            navigationBuilder.Property(s => s.Transmission)
            .HasColumnName("Transmission")
            .HasMaxLength(100)
            .IsRequired();

            navigationBuilder.Property(s => s.Fuel)
            .HasColumnName("Fuel")
            .HasMaxLength(100)
            .IsRequired();

        });

        //Brand - Car İlişkisi
        builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        //restrict ile silinmeyi engelliyoruz


    }
}
