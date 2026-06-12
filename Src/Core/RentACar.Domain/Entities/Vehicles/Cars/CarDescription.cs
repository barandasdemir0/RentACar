using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Vehicles.Cars;

public sealed class CarDescription:BaseEntity
{
    public Guid CarId { get; private set; }
    public Car Car { get; private set; } = null!;
    public string Details { get; private set; }

    private CarDescription()
    {
        Details = null!;
    }

    public CarDescription(Guid carId,string details)
    {
        if (carId == Guid.Empty)
        {
            throw new ArgumentException("Car Id boş olamaz.", nameof(carId));
        }
        ArgumentException.ThrowIfNullOrWhiteSpace(details);

        CarId = carId;
        Details = details;
    }
    public void UpdateCarDescription(string details)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(details);

        Details = details;
    }
}
