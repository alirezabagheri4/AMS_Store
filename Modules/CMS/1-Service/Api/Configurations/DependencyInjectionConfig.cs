using Infra.Ioc;

namespace Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            Infra.Ioc.NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}
