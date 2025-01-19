using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pos;

public static class PosModule
{
    public static IServiceCollection AddPosModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UsePosModule(this IApplicationBuilder app)
    {
        return app;
    }

}