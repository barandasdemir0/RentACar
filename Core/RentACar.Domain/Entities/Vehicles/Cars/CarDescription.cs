namespace RentACar.Domain.Entities.Vehicles.Cars;

public class CarDescription
{
    public int CarDescriptionID { get; set; }
    public int CarID { get; set; }
    public Car? Car { get; set; }
    public string? CarDescriptionDetails { get; set; }
}
