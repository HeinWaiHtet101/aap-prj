

using Microsoft.FeatureManagement;
using Todo.Domain.Services;

namespace Todo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        services.AddFeatureManagement();
        return services;
    }
}