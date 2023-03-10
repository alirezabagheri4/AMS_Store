using Application.AutoMapper;
using Application.AutoMapper.Product;

namespace Api.ConfigurationsExtensions;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(
            typeof(ProductDomainToViewModelMappingProfile),
            typeof(ProductDomainToViewModelMappingProfile));
    }
}