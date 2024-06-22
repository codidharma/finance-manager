using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using WebApi.Common.EndpointCustomizations;

namespace WebApi.UnitTests.EndpointCustomizations;

public class RouteGroupServiceExtensionsTests
{
    [Fact]
    public void WhenContainerAssemblyIsProvided_Then_AddRouteGroupFindsAllImplementationsOfIRouteGroup()
    {
        //Arrange
        var services = new ServiceCollection();
        var expectedCountOfImplementations = 1;

        //Act
        services.AddRouteGroupsInAssemblyContaining<DummyRouteGroup>();

        var actualCountOfImplementations = services.Count(x => x.ServiceType == typeof(IRouteGroup));

        //Assert
        actualCountOfImplementations.Should().Be(expectedCountOfImplementations);
    }

    [Fact]
    public void GivenAllImplementationsOfIRouteGroup_ThenMapGroupMapsAllEndpoints()
    {
        //Arrange
        var builder = WebApplication.CreateSlimBuilder();
        builder.Services.AddRouteGroupsInAssemblyContaining<DummyRouteGroup>();
        
        //Act
        var app = builder.Build();
        Action mapRoutegRoups = () => app.MapRouteGroups();

        //Assert
        mapRoutegRoups.Should().NotThrow();
    }
}
