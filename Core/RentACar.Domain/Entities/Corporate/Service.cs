using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Corporate;

public sealed class Service:AggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Icon { get; private set; }
    public string? IconUrl { get; private set; }

    private Service()
    {
        Title = null!;
        Description = null!;
        Icon = null!;
    }

    public Service(string title, string description, string icon, string? iconUrl=null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(icon);

        Title = title;
        Description = description;
        Icon = icon;
        IconUrl = iconUrl;
    }
    public void UpdateService(string title, string description, string icon, string? iconUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(icon);

        Title = title;
        Description = description;
        Icon = icon;
        IconUrl = iconUrl;
    }
}
