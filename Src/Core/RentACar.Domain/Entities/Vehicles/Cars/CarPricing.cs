using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Rentals;

namespace RentACar.Domain.Entities.Vehicles.Cars;

public sealed class CarPricing:BaseEntity
{
    public Guid CarId { get; private set; }
    public Car Car { get; private set; } = null!;
    public Guid PricingId { get; private set; }
    public Pricing Pricing { get; private set; } = null!;
    public decimal  Amount { get; private set; }//miktar
    private CarPricing()
    {
        
    }
    public CarPricing(Guid carId,Guid pricingId,decimal amount)
    {
        if (carId == Guid.Empty)
        {
            throw new ArgumentException("Car Id Boş olamaz", nameof(carId));
        }
        if (pricingId == Guid.Empty)
        {
            throw new ArgumentException("Pricing Id Boş Olamaz", nameof(pricingId));
        }

        if (amount<=0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Kiralama bedeli 0 veya eksi olamaz.");
        }

        CarId = carId;
        PricingId = pricingId;
        Amount = amount;
    }

    public void UpdateCarPricing(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Kiralama bedeli 0 veya eksi olamaz.");
        }
        Amount = amount;
    }
}
