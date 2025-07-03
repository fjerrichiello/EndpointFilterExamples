namespace EndpointFiltersExample.Accessor;

public class AuthContextAccessor
{
    public object Data { get; set; }

    public List<bool> RequestAuthorized { get; set; }
}