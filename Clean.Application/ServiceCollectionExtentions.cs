using Clean.Application.Common.PipelineBehaviors;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.Application;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddMapperConfiguration(this IServiceCollection services)
    {
        services.AddMapster();
        return services;
    }

    public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        { 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        return services;
    }
}
