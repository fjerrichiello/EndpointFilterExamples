using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public class MemberEndpointFilter(AuthContextAccessor _authContextAccessor)
    : BaseEndpointAuthorizationFilter(_authContextAccessor)
{
    protected override Task<bool> AuthorizeAsync(EndpointFilterInvocationContext context)
    {
        var membersParam = context.GetArgument<string[]>(0);
        return Task.FromResult(membersParam.Any(x => _authContextAccessor.Data.Contains(x)));
    }
}