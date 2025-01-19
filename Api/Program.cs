using System.Reflection;
using Carter;
using Membership;
using Pos;
using Shared.Exceptions.Handler;
using Shared.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Assembly membershipAssembly = typeof(MembershipModule).Assembly;
Assembly posAssembly = typeof(PosModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(membershipAssembly,posAssembly);

builder.Services
    .AddMediatRWithAssemblies(membershipAssembly,posAssembly);

builder.Services
    .AddMembershipModule(builder.Configuration)
    .AddPosModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddOpenApi();

builder.Services.AddSwagger();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Modified V.2");
        c.RoutePrefix = string.Empty;
    });
}

app.MapCarter();

app.UseMembershipModule()
    .UsePosModule();



app.Run();