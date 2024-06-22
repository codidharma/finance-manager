namespace WebApi.Common.EndpointCustomizations;

public static class RouteGroupServiceExtensions
{
    public static IServiceCollection AddRouteGroupsInAssemblyContaining<T>(this IServiceCollection services)
    {
        var assembly = typeof(T).Assembly;

        var foundRouteGroups = assembly.GetTypes()
            .Where(t =>
                !t.IsAbstract &&
                t.IsClass && !t.IsInterface &&
                t.IsAssignableTo(typeof(IRouteGroup))
             );

        foreach (var foundRouteGroup in foundRouteGroups)
        {
            services.AddSingleton(typeof(IRouteGroup), foundRouteGroup);
        }

        return services;
    }

    public static IEndpointRouteBuilder MapRouteGroups(this IEndpointRouteBuilder builder)
    {
        var registeredRouteGroups = builder.ServiceProvider.GetServices<IRouteGroup>();

        foreach (var registeredRouteGroup in registeredRouteGroups)
        {
            registeredRouteGroup.Register(builder);
        }
        return builder;
    }
}
