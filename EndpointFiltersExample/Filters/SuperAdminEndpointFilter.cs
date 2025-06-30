using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public class SuperAdminEndpointFilter(AuthContextAccessor _authContextAccessor) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        Console.WriteLine("super admin view endpoint");
        if (_authContextAccessor.Data != "SuperAdmin")
        {
            _authContextAccessor.RequestAuthorized.Add(false);
        }

        var result = await next(context);
        return result;
    }
}