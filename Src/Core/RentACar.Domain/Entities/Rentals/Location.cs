using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Rentals;

public sealed class Location : AggregateRoot
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    private Location()
    {
        Name = null!;
    }

    public Location(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
        IsActive = false;
    }
    public void UpdateLocation(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
        IsActive = false;
    }

    public void ActivateLocation() => IsActive = true;
    public void DeActivateLocation() => IsActive = false;
}
