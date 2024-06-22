
using FluentAssertions;
using NetArchTest.Rules;
using WebApi.Common.EndpointCustomizations;

namespace WebApi.ArchitectureTests;

public class EndpointCustomizationTests
{
    [Fact]
    public void IRouteGroup_Interface_Should_Only_Have_One_Method()
    {
        //Arrange
        var expectedNumberofMethods = 1;

        //Act
        var result = typeof(IRouteGroup).GetMethods();

        //Assert
        result.Count().Should().Be(expectedNumberofMethods);
            
    }
}
