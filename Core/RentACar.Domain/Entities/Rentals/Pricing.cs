using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Vehicles.Cars;

namespace RentACar.Domain.Entities.Rentals;

public sealed class Pricing:AggregateRoot
{
    public string Name { get; private set; }

    // 1. GİZLİ KASA (Arka Depo)
    // Sadece bu sınıfın (Patronun) görebildiği ve değiştirebildiği asıl liste.
    // Dışarıdan kimse erişemez, kafasına göre '.Add()' veya '.Clear()' yapamaz.
    private readonly List<CarPricing> _carPricings = new();
    // 2. CAM VİTRİN (Sadece Okunabilir Liste)
    // Dış dünyadaki sınıfların (API, Servisler) bakabileceği vitrin.
    // Dışarıdakiler listenin içindekileri görür, okur ama vitrini kırıp yeni eleman ekleyemez.
    public IReadOnlyCollection<CarPricing> CarPricings => _carPricings.AsReadOnly();

    private Pricing()
    {
        Name = null!;
    }

    public Pricing(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }

    // 3. PATRONUN İZNİ (Kontrollü Ekleme)
    // Vitrine dışarıdan müdahale yasak olduğu için, listeye yeni fiyat eklenecekse 
    // mecburen patronun bu metodu (kapısı) kullanılmak zorundadır.
    public void AddCarPricing(CarPricing carPricing)
    {
        _carPricings.Add(carPricing);
    }

    public void UpdatePricing(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}
