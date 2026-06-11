using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;

namespace RentACar.Domain.Entities.Vehicles.Cars;



public sealed class Car : AggregateRoot
{
    public Guid BrandID { get; private set; }
    public Brand Brand { get; private set; } = null!;
    public string? Model { get; private set; }
    public CarImages Images { get; private set; }
    public CarSpecifications Specifications { get; private set; }

    private readonly List<CarFeature> _features = new();
    public IReadOnlyCollection<CarFeature> Features => _features.AsReadOnly();

    private readonly List<CarDescription> _descriptions = new();
    public IReadOnlyCollection<CarDescription> Descriptions => _descriptions.AsReadOnly();

    private readonly List<CarPricing> _pricings = new();
    public IReadOnlyCollection<CarPricing> Pricings => _pricings.AsReadOnly();

    private Car()
    {
        Model = null!;
        Images = null!;
        Specifications = null!;
    }
    public Car(Guid brandId , string model, CarImages images, CarSpecifications specifications)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentNullException.ThrowIfNull(images);
        ArgumentNullException.ThrowIfNull(specifications);

        BrandID = brandId;
        Model = model;
        Images = images;
        Specifications = specifications;
    }

    public void UpdateCar(Guid brandId , string model, CarImages images, CarSpecifications specifications)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentNullException.ThrowIfNull(images);
        ArgumentNullException.ThrowIfNull(specifications);

        BrandID = brandId;
        Model = model;
        Images = images;
        Specifications = specifications;
    }

    public void AddFeature(CarFeature feature) => _features.Add(feature);
    public void AddDescription(CarDescription description) => _descriptions.Add(description);
    public void AddPricing(CarPricing pricing) => _pricings.Add(pricing);

}

