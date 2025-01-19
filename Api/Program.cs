using System.Reflection;
using Carter;
using Membership;
using Pos;
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

WebApplication app = builder.Build();

app.MapCarter();

app.UseMembershipModule()
    .UsePosModule();

app.Run();