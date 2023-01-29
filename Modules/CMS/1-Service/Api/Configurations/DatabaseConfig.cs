

using Infra.Data.Data.Context;
using Infra.Data.Data.Framework;
using Microsoft.EntityFrameworkCore;

namespace Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<CustomerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .AddInterceptors(new AddAuditFieldInterceptor()));
        }
    }
}
