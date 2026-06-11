using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Domain.Entities.Vehicles;

public class Brand : BaseEntity
{
    public string BrandName { get; set; } = default!;
    public List<Car>? Cars { get; set; }
}
