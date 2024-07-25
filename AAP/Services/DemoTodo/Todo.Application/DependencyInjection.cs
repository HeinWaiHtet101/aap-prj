

using Microsoft.FeatureManagement;

namespace Todo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //var assembly = Assembly.GetExecutingAssembly();
        //services.AddMediatR(config =>
        //{
        //    config.RegisterServicesFromAssembly(assembly);
        //    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        //    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        //});

        //services.AddValidatorsFromAssembly(assembly);
        services.AddFeatureManagement();
        return services;
    }
}