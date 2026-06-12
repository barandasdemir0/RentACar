using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Domain.Entities.Rentals;

public sealed class Pricing:AggregateRoot
{
    public string Name { get; private set; }


    private Pricing()
    {
        Name = null!;
    }

    public Pricing(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }



    public void UpdatePricing(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }
}
