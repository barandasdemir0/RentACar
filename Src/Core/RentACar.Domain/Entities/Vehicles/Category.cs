using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Vehicles;

public sealed class Category:AggregateRoot
{
    public string Name { get; private set; }
    private Category()
    {
        Name = null!;
    }

    public Category(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }

    public void UpdateCategory(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }
}
