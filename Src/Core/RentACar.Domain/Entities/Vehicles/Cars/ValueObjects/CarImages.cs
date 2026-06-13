namespace RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;

public sealed record CarImages
{
    public string CoverImageUrl { get; private init; }
    public string BigImageUrl { get; private init; }

    public CarImages(string coverImageUrl, string bigImageUrl)
    {
        // Resim linkleri boş olamaz
        ArgumentException.ThrowIfNullOrWhiteSpace(coverImageUrl);
        ArgumentException.ThrowIfNullOrWhiteSpace(bigImageUrl);

        var trimmedCover = coverImageUrl.Trim();
        var trimmedBig = bigImageUrl.Trim();
        // Ekstra: URL format kontrolü
        if (!trimmedCover.StartsWith("http") || !trimmedBig.StartsWith("http"))
        {
            throw new ArgumentException("Geçersiz URL formatı. Linkler 'http' ile başlamalıdır.");
        }
        CoverImageUrl = trimmedCover;
        BigImageUrl = trimmedBig;
    }
}
