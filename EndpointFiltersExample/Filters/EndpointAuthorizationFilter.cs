using EndpointFiltersExample.Accessor;
using EndpointFiltersExample.DataFactory;
using EndpointFiltersExample.Verifier;
using Microsoft.AspNetCore.Mvc;

namespace EndpointFiltersExample.Filters;

public class EndpointAuthorizationFilter<TUnverifiedData>(
    AuthContextAccessor _authContextAccessor,
    IRequestDataFactory<TUnverifiedData> _requestDataFactory,
    IAuthorizedRequestVerifier<TUnverifiedData> _authorizedRequestVerifier) : IEndpointFilter
{
    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var data = await _requestDataFactory.GetUnverifiedDataAsync(context, _authContextAccessor.Data);

        var result = _authorizedRequestVerifier.Authorize(data);

        if (result.IsValid)
        {
            return await next(context);
        }

        return TypedResults.Problem(new ProblemDetails() { Status = StatusCodes.Status403Forbidden });
    }
}