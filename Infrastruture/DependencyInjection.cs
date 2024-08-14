using Domain.Interfaces;
using Infrastruture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastruture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruture(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddSingleton<IGunFakeService, GunFakeService>();
        return services;
    }
}
