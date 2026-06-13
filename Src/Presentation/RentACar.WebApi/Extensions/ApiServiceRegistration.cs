using RentACar.Domain.Entities.Common.Interfaces;

namespace RentACar.WebApi.Extensions;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, FakeCurrentUserService>();

        return services;

    }
}
