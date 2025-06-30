using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Filters;

public class AuthResultFilter(AuthContextAccessor _authContextAccessor) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        Console.WriteLine("Auth result view endpoint");
        if (_authContextAccessor.RequestAuthorized.Contains(false))
        {
            return TypedResults.Unauthorized();
        }

        var result = await next(context);
        return result;
    }
}