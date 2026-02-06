using Core.Abstractions.Persistence;
using Core.Abstractions.Persistence.Repositories;
using DataAccess.InMemory.Persistence;
using DataAccess.InMemory.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.InMemory;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IPersistenceContext, PersistenceContext>();

        services.AddSingleton<IAdminSessionRepository, AdminSessionRepository>();
        services.AddSingleton<IHistoryRepository, HistoryRepository>();
        services.AddSingleton<IPasswordRepository, PasswordRepository>();
        services.AddSingleton<IPersonAccountRepository, PersonAccountRepository>();
        services.AddSingleton<ISessionRepository, SessionRepository>();

        return services;
    }
}
