namespace WebApi.Common.EndpointCustomizations;
public interface IRouteGroup
{
    public void Register(IEndpointRouteBuilder routeBuilder);
}
