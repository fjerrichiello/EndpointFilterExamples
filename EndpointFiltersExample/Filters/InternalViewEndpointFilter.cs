using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public class InternalViewEndpointFilter(AuthContextAccessor _authContextAccessor) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        Console.WriteLine("Internal view endpoint");
        if (_authContextAccessor.Data != "InternalView")
        {
            _authContextAccessor.RequestAuthorized.Add(false);
        }

        var result = await next(context);
        return result;
    }
}