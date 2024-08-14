using Domain.Entities;
using Domain.Interfaces;
using Infrastruture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastruture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruture(this IServiceCollection services)
    {
        services.AddScoped<IGunRepository, GunRepository>();
        services.AddSingleton<IGunFakeContext, GunFakeContext>();
        services.AddSingleton<Gun>();
        return services;
    }
}
