using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Domain.Entities.Vehicles;

public sealed class Brand : AggregateRoot
{
    public string Name { get; private set; }

    private Brand()
    {
        Name = null!;
    }

    public Brand(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name.Trim();
    }

    public void UpdateBrand(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name.Trim();
    }
}
