using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApi.Common.EndpointCustomizations;

namespace WebApi.UnitTests.EndpointCustomizations;

public class DummyRouteGroup : IRouteGroup
{
    public void Register(IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("/dummyRoute");

        group.MapGet("/", () => { return "Hello World!"; });
        group.MapGet("/geyById", () => { return $"Hello World for id"; });
    }
}
