using RentACar.Domain.Entities.Rentals;

namespace RentACar.Domain.Entities.Vehicles.Cars;

public class CarPricing
{
    public int CarPricingID { get; set; }
    public int CarID { get; set; }
    public Car?  Car { get; set; }
    public int PricingID { get; set; }
    public Pricing?  Pricing { get; set; }
    public decimal  Amount { get; set; }//miktar
}
