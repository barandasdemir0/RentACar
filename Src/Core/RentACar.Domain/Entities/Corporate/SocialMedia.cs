using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class SocialMedia:AggregateRoot
{
    public string Name { get; private set; }
    public string Url { get; private set; }
    public string Icon { get; private set; }

    private SocialMedia()
    {
        Name = null!;
        Url = null!;
        Icon = null!;
    }
    public SocialMedia(string name, string url, string icon)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        ArgumentException.ThrowIfNullOrWhiteSpace(icon);
        Name = name.Trim();
        Url = url.Trim();
        Icon = icon.Trim();
    }
    public void UpdateSocialMedia(string name, string url, string icon)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        ArgumentException.ThrowIfNullOrWhiteSpace(icon);
        Name = name.Trim();
        Url = url.Trim();
        Icon = icon.Trim();
    }
}
