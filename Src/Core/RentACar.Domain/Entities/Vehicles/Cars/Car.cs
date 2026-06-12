using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars.Enum;
using RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;

namespace RentACar.Domain.Entities.Vehicles.Cars;

public sealed class Car : AggregateRoot
{
    public Guid BrandId { get; private set; }
    public Brand Brand { get; private set; } = null!;
    public string Model { get; private set; }
    public CarImages Images { get; private set; }
    public CarSpecifications Specifications { get; private set; }
    public CarStatus Status { get; private set; }

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
    public Car(Guid brandId, string model, CarImages images, CarSpecifications specifications)
    {
        if (brandId == Guid.Empty)
        {
            throw new ArgumentException("Brand Id boş olamaz.", nameof(brandId));
        }
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentNullException.ThrowIfNull(images);
        ArgumentNullException.ThrowIfNull(specifications);

        BrandId = brandId;
        Model = model.Trim();
        Images = images;
        Specifications = specifications;
        Status = CarStatus.Available;
    }

    public void UpdateCar(Guid brandId, string model, CarImages images, CarSpecifications specifications)
    {
        if (brandId == Guid.Empty)
        {
            throw new ArgumentException("Brand Id boş olamaz.", nameof(brandId));
        }
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentNullException.ThrowIfNull(images);
        ArgumentNullException.ThrowIfNull(specifications);

        BrandId = brandId;
        Model = model.Trim();
        Images = images;
        Specifications = specifications;
    }

    public void AddFeature(CarFeature feature)
    {
        ArgumentNullException.ThrowIfNull(feature);
        _features.Add(feature);
    }
    public void AddDescription(CarDescription description)
    {
        ArgumentNullException.ThrowIfNull(description);
        _descriptions.Add(description);
    }
    public void AddPricing(CarPricing pricing)
    {
        ArgumentNullException.ThrowIfNull(pricing);
        _pricings.Add(pricing);
    }

    public void SendToMaintenance() => Status = CarStatus.Maintenance;
    public void ReturnFromMaintenance() => Status = CarStatus.Available;

    public void RentCar()
    {
        if (Status!=CarStatus.Available)
        {
            throw new InvalidOperationException("Müsait olmayan araç kiralanamaz");

            
        }
        Status = CarStatus.Rented;


    }

    public void ReturnCar() => Status = CarStatus.Available;



}

