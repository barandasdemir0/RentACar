using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Common.Interfaces;
using RentACar.Domain.Entities.Corporate;
using RentACar.Domain.Entities.Rentals;
using RentACar.Domain.Entities.Vehicles;
using RentACar.Domain.Entities.Vehicles.Cars;
using System.Security.Claims;

namespace RentACar.Persistence.Context;

public sealed class CarBookContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    public CarBookContext(DbContextOptions<CarBookContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<FooterAddress> FooterAddresses { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<Car> Car { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Feature> Features { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarBookContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

       
        //bilinmeyen kullanıcı istek attığın da site çökmesin diye boş guid
        Guid userId;
        if (_currentUserService.UserId != null)
        {
            userId = _currentUserService.UserId.Value;
        }
        else
        {
            userId = Guid.Empty;
        }

       

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedAt).CurrentValue = DateTimeOffset.UtcNow;
                entry.Property(p => p.CreatedBy).CurrentValue = userId;
            }
            else if (entry.State == EntityState.Modified)
            {
                bool isJustDeleted = entry.Property(p => p.IsDeleted).IsModified &&
                    entry.Property(p => p.IsDeleted).CurrentValue == true;

                if (isJustDeleted)
                {
                    entry.Property(p => p.DeletedAt).CurrentValue = DateTimeOffset.UtcNow;
                    entry.Property(p => p.DeletedBy).CurrentValue = userId;
                }
                else
                {
                    entry.Property(p => p.UpdatedAt).CurrentValue = DateTimeOffset.UtcNow;
                    entry.Property(p => p.UpdatedBy).CurrentValue = userId;
                }
            }
            if (entry.State == EntityState.Deleted)
            {
                throw new ArgumentException("Db'den direkt silme işlemi yapamazsınız");
            }
        }


        return base.SaveChangesAsync(cancellationToken);

    }
}
