namespace RentACar.Domain.Entities.Vehicles.Cars.ValueObjects;

public record CarImages
{
    public string CoverImageUrl { get; init; }
    public string BigImageUrl { get; init; }

    public CarImages(string coverImageUrl, string bigImageUrl)
    {
        // Resim linkleri boş olamaz
        ArgumentException.ThrowIfNullOrWhiteSpace(coverImageUrl);
        ArgumentException.ThrowIfNullOrWhiteSpace(bigImageUrl);

        // Ekstra: URL format kontrolü
        if (!coverImageUrl.StartsWith("http"))
            throw new ArgumentException("Geçersiz URL formatı.", nameof(coverImageUrl));

        CoverImageUrl = coverImageUrl;
        BigImageUrl = bigImageUrl;
    }
}
