using Membership.Modules.Contracts;

namespace Membership.Modules.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddModulesRepositories(this IServiceCollection services)
    {
        services.AddScoped<IModuleQueryRepository, ModuleQueryEfCoreRepository>();

        return services;
    }
}