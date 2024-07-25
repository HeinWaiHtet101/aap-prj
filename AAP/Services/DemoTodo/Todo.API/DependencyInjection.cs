

namespace Todo.API;
public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var assembly = typeof(Todo.Application.DependencyInjection).Assembly;
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        services.AddValidatorsFromAssembly(assembly);

        services.AddExceptionHandler<CustomExceptionHandler>();

        //var connectionString = configuration.GetConnectionString("Database");
        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(
        //        connectionString,
        //        b => b.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName)),
        //        ServiceLifetime.Scoped);

        //services.AddScoped<ITodoRepository, TodoRepository>();

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        return app;
    }
}
