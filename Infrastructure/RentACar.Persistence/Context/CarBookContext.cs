using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entities.Common;
using RentACar.Domain.Entities.Corporate;
using System.Security.Claims;

namespace RentACar.Persistence.Context;

internal sealed class CarBookContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CarBookContext(DbContextOptions<CarBookContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<About> Abouts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

       
        //bilinmeyen kullanıcı istek attığın da site çökmesin diye boş guid
        Guid userId = Guid.Empty;
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext?.User?.Identity?.IsAuthenticated==true)
        {
            var userClaim = httpContext.User.Claims.FirstOrDefault(p => p.Type == "sub" || p.Type == ClaimTypes.NameIdentifier);
            if (userClaim!=null)
            {
                Guid.TryParse(userClaim.Value, out userId);
            }
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
