namespace EndpointFiltersExample.DataFactory;

public interface IRequestDataFactory<TUnverifiedData>
{
    Task<TUnverifiedData> GetUnverifiedDataAsync(EndpointFilterInvocationContext context,
        object MessageAuthorizationContext);
}