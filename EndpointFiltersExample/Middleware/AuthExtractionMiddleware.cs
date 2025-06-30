using System.Globalization;
using EndpointFiltersExample.Accessor;

namespace EndpointFiltersExample.Middleware;

public class AuthExtractionMiddleware(RequestDelegate _next, AuthContextAccessor _authContextAccessor)
{
    public async Task InvokeAsync(HttpContext context)
    {
        _authContextAccessor.Data = context.Request.Headers["CustomAuthorization"]!;
        _authContextAccessor.RequestAuthorized = [];

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}