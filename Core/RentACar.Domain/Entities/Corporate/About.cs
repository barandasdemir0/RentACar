using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class About : AggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string? ImageUrl { get; private set; }


    //efcore veritabanından veri okurken kullanır burayı
    private About()
    {
        Title = null!;
        Description = null!;
    }

    //yeni bir kayıt oluştururken çalışacak kurallar
    public About(string title, string description, string? imageUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        Title = title;
        Description = description;
        ImageUrl = imageUrl;
    }

    //var olan kaydı güncellerken oluşacak kurallar
    public void UpdateContent(string title, string description, string? imageUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
    }
}
//ThrowIfNullOrWhiteSpace nedir ? null olup olmadığıu boş string olup olmadığğı sadece boşluklardan oluşup oluşmadığı