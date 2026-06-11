namespace RentACar.Domain.Entities;

public class Pricing
{
    public int PricingID { get; set; }
    public string? PricingName { get; set; }
    public List<CarPricing>? CarPricings { get; set; }
}
