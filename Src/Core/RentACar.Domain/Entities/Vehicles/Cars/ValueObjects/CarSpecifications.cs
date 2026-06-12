namespace RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;

public sealed record CarSpecifications
{
    public int Kilometer { get; private init; }
    public string Transmission { get; private init; }
    public byte Seats { get; private init; }
    public byte Luggage { get; private init; }
    public string Fuel { get; private init; }

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
        Transmission = transmission.Trim();
        Seats = seats;
        Luggage = luggage;
        Fuel = fuel;
    }
}
