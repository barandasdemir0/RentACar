namespace RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;

public record CarSpecifications
{
    public int Kilometer { get; init; }
    public string Transmission { get; init; }
    public byte Seats { get; init; }
    public byte Luggage { get; init; }
    public string Fuel { get; init; }

    public CarSpecifications(int kilometer, string transmission, byte seats, byte luggage, string fuel)
    {
        if (kilometer < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(kilometer), "Kilometre 0'dan küçük olamaz.");
        }
        if (seats <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(seats), "Koltuk sayısı 0 veya eksi olamaz.");
        }
        if (luggage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(luggage), "Bagaj kapasitesi eksi olamaz.");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(transmission);
        ArgumentException.ThrowIfNullOrWhiteSpace(fuel);

        Kilometer = kilometer;
        Transmission = transmission;
        Seats = seats;
        Luggage = luggage;
        Fuel = fuel;
    }
}
