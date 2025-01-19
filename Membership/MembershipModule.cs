namespace Membership;

public static class MembershipModule
{
    public static IServiceCollection AddMembershipModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("MembershipConnection") ??
                                  throw new ArgumentNullException(nameof(configuration));
        
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        
        services.AddDbContext<MembershipDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        
        return services;
    }
    
    public static IApplicationBuilder UseMembershipModule(this IApplicationBuilder app)
    {
        return app;
    }
    
}