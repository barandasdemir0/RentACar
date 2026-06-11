namespace RentACar.Domain.Entities;

public class Banner : BaseEntity
{
    public string BannerTitle { get; set; } = string.Empty;
    public string BannerDescription { get; set; } = string.Empty;
    public string? BannerVideoDescription { get; set; }
    public string? BannerVideoUrl { get; set; } 
    public string? BannerImageUrl { get; set; }
}
