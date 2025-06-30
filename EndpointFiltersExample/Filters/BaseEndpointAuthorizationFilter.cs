using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public abstract class BaseEndpointAuthorizationFilter(AuthContextAccessor _authContextAccessor) : IEndpointFilter
{
    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        Console.WriteLine("Auth result view endpoint");

        var authorizationCheck = await AuthorizeAsync(context);
        _authContextAccessor.RequestAuthorized.Add(authorizationCheck);

        var result = await next(context);
        return result;
    }

    protected abstract Task<bool> AuthorizeAsync(EndpointFilterInvocationContext context);
}