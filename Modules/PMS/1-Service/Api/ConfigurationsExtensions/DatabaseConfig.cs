using Infra.Data.Persistence.Context;
using Infra.Data.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Api.ConfigurationsExtensions;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ProductManagementDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(new AddAuditFieldInterceptor()));
    }
}