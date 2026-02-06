using Core.Contracts;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAtmService, AtmService>();
        return services;
    }
}