using Api.ConfigurationsExtensions;
using MediatR;

namespace Api.Extensions;

public static class ServiceExtension
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Setting DBContexts
        builder.Services.AddDatabaseConfiguration(builder.Configuration);

        // ASP.NET Identity Settings & JWT
        //builder.Services.AddApiIdentityConfiguration(builder.Configuration);

        // Interactive AspNetUser (logged in)
        // NetDevPack.Identity dependency
        //builder.Services.AddAspNetUserConfiguration();

        // AutoMapper Settings
        builder.Services.AddAutoMapperConfiguration();

        // Swagger Config
        builder.Services.AddSwaggerConfiguration();

        // Adding MediatR for Domain Events and Notifications
        builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDependencyInjectionConfiguration();
        return builder.Build();
    }
}