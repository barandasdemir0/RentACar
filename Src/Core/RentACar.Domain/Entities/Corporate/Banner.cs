using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class Banner : AggregateRoot
{
    public string Title { get; private set; } 
    public string Description { get; private set; } 
    public string? VideoDescription { get; private set; }
    public string? VideoUrl { get; private set; } 

    private Banner()
    {
        Title = null!;
        Description = null!;
    }
    public Banner(string title, string description , string? videoDescription=null,string? videoUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        Title = title;
        Description = description;
        // VideoDescription için boşluk temizliği
        if (string.IsNullOrWhiteSpace(videoDescription))
        {
            VideoDescription = null;
        }
        else
        {
            VideoDescription = videoDescription;
        }

        // VideoUrl için boşluk temizliği
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            VideoUrl = null;
        }
        else
        {
            VideoUrl = videoUrl;
        }
    }

    public void UpdateBanner(string title, string description, string? videoDescription = null, string? videoUrl=null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        Title = title;
        Description = description;
        // VideoDescription için boşluk temizliği
        if (string.IsNullOrWhiteSpace(videoDescription))
        {
            VideoDescription = null;
        }
        else
        {
            VideoDescription = videoDescription;
        }

        // VideoUrl için boşluk temizliği
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            VideoUrl = null;
        }
        else
        {
            VideoUrl = videoUrl;
        }
    }




}
