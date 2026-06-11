using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Domain.Entities.Vehicles;

public class Feature
{
    public int FeatureID { get; set; }
    public string? FeatureName { get; set; }
    public List<CarFeature>? CarFeatures { get; set; }
}
