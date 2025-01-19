using Membership.Modules.Repositories;

namespace Membership.Modules;

public static class DependencyInjection
{
    public static IServiceCollection AddModulesServices(this IServiceCollection services)
    {
        services.AddModulesRepositories();
        
        return services;
    }

}