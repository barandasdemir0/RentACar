using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Persistence.Context;

namespace RentACar.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<CarBookContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
        });


        return services;
    }
}
