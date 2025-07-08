using Dumpify;
using Microsoft.Extensions.Primitives;

namespace EndpointFiltersExample.DataFactory;

public class NewDataFactory : IRequestDataFactory<NewData>
{
    public Task<NewData> GetUnverifiedDataAsync(EndpointFilterInvocationContext context,
        object MessageAuthorizationContext)
    {
        List<string> passedIds = [];

        if (context.HttpContext.Request.Query.TryGetValue("member_id", out var ids))
        {
            passedIds = ids.Select(x => x).ToList()!;
        }
        else if (context.HttpContext.Request.RouteValues.TryGetValue("member_id", out var id))
        {
            passedIds = [id!.ToString()!];
        }

        passedIds.Dump();

        return Task.FromResult(new NewData());
    }
}