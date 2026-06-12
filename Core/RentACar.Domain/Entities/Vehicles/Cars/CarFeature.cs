using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities.Vehicles.Cars;

public sealed class CarFeature : BaseEntity
{
    public Guid CarId { get; private set; }
    public Car Car { get; private set; } = null!;

    public Guid FeatureId { get; private set; }
    public Feature Feature { get; private set; } = null!;

    public bool Available { get; private set; }

    private CarFeature()
    {
    }

    public CarFeature(Guid carId, Guid featureId,bool available)
    {
        if (carId==Guid.Empty)
        {
            throw new ArgumentException("Car Id Boş olamaz", nameof(carId));
        }
        if (featureId== Guid.Empty)
        {
            throw new ArgumentException("Feature Id Boş olamaz", nameof(featureId));
        }
        CarId = carId;
        FeatureId = featureId;
        Available = available; 
    }

   
    public void MarkAsAvailable() => Available = true;
    public void MarkAsUnavailable() => Available = false;


}
