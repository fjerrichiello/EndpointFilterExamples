namespace EndpointFiltersExample.DataFactory;

public class NewDataFactory : IRequestDataFactory<NewData>
{
    public Task<NewData> GetUnverifiedDataAsync(EndpointFilterInvocationContext context, object MessageAuthorizationContext)
    {
        throw new NotImplementedException();
    }
}