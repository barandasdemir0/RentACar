using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Rentals;

public sealed class Location : AggregateRoot
{
    public string Name { get; private set; }
    private Location()
    {
        Name = null!;
    }

    public Location(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
    public void UpdateLocation(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}
