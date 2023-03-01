using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vitasmart.Application;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Application.Interfaces;
using Vitasmart.Persistence.Npgsql;
using Vitasmart.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {

    }
}

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
    });

    services.AddApplication();
    services.AddPersistence(builder.Configuration);
    services.AddControllers();

    services.AddCors(option =>
    {
        option.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });
}

void Configure(WebApplication app)
{

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseCustomExceptionHandler();
    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseCors("AllowAll");

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    //app.UseEndpoints(endpoints =>
    //{
    //    endpoints.MapControllers()!;
    //});
}