using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Domain.Entities.Vehicles;

public sealed class Feature:AggregateRoot
{
    public string Name { get; private set; }

    private Feature()
    {
        Name = null!;
    }

    public Feature(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }

    public void UpdateFeature(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }

}
