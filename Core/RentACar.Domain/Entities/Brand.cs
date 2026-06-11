namespace RentACar.Domain.Entities;

public class Brand : BaseEntity
{
    public string BrandName { get; set; } = default!;
    public List<Car>? Cars { get; set; }
}
