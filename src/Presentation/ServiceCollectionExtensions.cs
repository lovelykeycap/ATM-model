using Core.Abstractions.AdminSettings;
using Presentation.AdminSettings;

namespace Presentation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<IAdminPasswordProvider, AdminPasswordProvider>();

        return services;
    }
}