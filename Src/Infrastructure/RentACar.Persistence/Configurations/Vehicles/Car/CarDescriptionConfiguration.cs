using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Persistence.Configurations.Vehicles.Car;

internal sealed class CarDescriptionConfiguration:BaseEntityConfiguration<CarDescription>
{
    public override void Configure(EntityTypeBuilder<CarDescription> builder)
    {
        base.Configure(builder);

        builder.ToTable("CarDescriptions");

        builder.Property(p => p.Details)
               .HasColumnType("text")
               .IsRequired();


        builder.HasOne(p => p.Car)
            .WithMany(p => p.Descriptions) //Car sınıfındaki IReadOnlyCollection listesine bağlandık
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Cascade); //Bağımlı alt tablo olduğu için Cascade!
    }
}
