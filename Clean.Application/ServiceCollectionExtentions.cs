using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddMapperConfiguration(this IServiceCollection services)
    {
        services.AddMapster();
        return services;
    }
}
