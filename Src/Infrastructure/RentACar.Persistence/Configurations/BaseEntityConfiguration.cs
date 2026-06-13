using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Common;

namespace RentACar.Persistence.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Id).IsUnique();

        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.CreatedBy).IsRequired();

        builder.Property(p => p.IsDeleted).HasDefaultValue(false);

        //silinmiş verileri otomatik eler listelerken
        builder.HasQueryFilter(p => !p.IsDeleted);

        //eğer veritabanına haritalanan bir sınıf aggreagateroot ise

        if (typeof(AggregateRoot).IsAssignableFrom(typeof(T)))
        {
            //domainevents işlemlerini yok saymaını söylüyoruz
            builder.Ignore("DomainEvents");
        }
    }
}
