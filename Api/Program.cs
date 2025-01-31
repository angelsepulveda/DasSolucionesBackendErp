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

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

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

app.UseCors("all"); 

app.MapCarter();

app.UseMembershipModule()
    .UsePosModule();



app.Run();