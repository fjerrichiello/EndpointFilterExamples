using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public class InternalViewEndpointFilter(AuthContextAccessor _authContextAccessor)
    : BaseEndpointAuthorizationFilter(_authContextAccessor)
{
    protected override Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(_authContextAccessor.Data == "InternalView");
    }
}