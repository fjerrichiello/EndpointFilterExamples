using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public class SuperAdminEndpointFilter(AuthContextAccessor _authContextAccessor)
    : BaseEndpointAuthorizationFilter(_authContextAccessor)
{
    protected override Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(_authContextAccessor.Data == "SuperAdmin");
    }
}